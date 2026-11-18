#!/usr/bin/env bash
set -Eeuo pipefail

ROOT_DIR="$(git rev-parse --show-toplevel 2>/dev/null || pwd)"
cd "$ROOT_DIR"

echo "== Syrla API: validação básica =="
echo "Diretório: $ROOT_DIR"

if ! command -v dotnet >/dev/null 2>&1; then
  echo "ERRO: .NET SDK não encontrado no PATH." >&2
  exit 1
fi

PROJECT_FILE="$(find . -maxdepth 4 -name '*.csproj' -not -path '*/bin/*' -not -path '*/obj/*' -print -quit)"
if [[ -z "$PROJECT_FILE" ]]; then
  echo "ERRO: nenhum arquivo .csproj encontrado." >&2
  exit 1
fi

echo
echo "Projeto encontrado: $PROJECT_FILE"

echo
echo "== dotnet --info (resumo) =="
dotnet --version

echo
echo "== Restore =="
dotnet restore "$PROJECT_FILE"

echo
echo "== Build =="
dotnet build "$PROJECT_FILE" --no-restore

echo
echo "== Testes =="
mapfile -t TEST_PROJECTS < <(
  find . -maxdepth 5 -name '*.csproj' \
    -not -path '*/bin/*' -not -path '*/obj/*' \
    | grep -Ei '(test|tests|spec)' || true
)

if (( ${#TEST_PROJECTS[@]} == 0 )); then
  echo "AVISO: nenhum projeto de testes identificado por nome. Testes não executados."
else
  for test_project in "${TEST_PROJECTS[@]}"; do
    echo "Executando: $test_project"
    dotnet test "$test_project" --no-restore
  done
fi

echo
echo "== Verificação Git =="
if git rev-parse --is-inside-work-tree >/dev/null 2>&1; then
  git diff --check
  git status --short --branch
else
  echo "AVISO: diretório não está em um repositório Git."
fi

echo
echo "Validação básica concluída."
