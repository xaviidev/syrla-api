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

mapfile -t PROJECT_FILES < <(
  find . -maxdepth 6 -type f -name '*.csproj' \
    -not -path '*/bin/*' -not -path '*/obj/*' \
    | sort
)

if (( ${#PROJECT_FILES[@]} == 0 )); then
  echo "ERRO: nenhum arquivo .csproj encontrado." >&2
  exit 1
fi

mapfile -t SOLUTION_FILES < <(
  find . -maxdepth 5 -type f \( -name '*.sln' -o -name '*.slnx' \) \
    -not -path '*/bin/*' -not -path '*/obj/*' \
    | sort
)

mapfile -t TEST_PROJECTS < <(
  for project in "${PROJECT_FILES[@]}"; do
    if grep -Eiq '<IsTestProject>[[:space:]]*true[[:space:]]*</IsTestProject>|Microsoft\.NET\.Test\.Sdk' "$project"; then
      printf '%s\n' "$project"
    fi
  done
)

echo
echo "Projetos encontrados: ${#PROJECT_FILES[@]}"
printf ' - %s\n' "${PROJECT_FILES[@]}"

echo
echo "== .NET SDK =="
dotnet --version

if (( ${#SOLUTION_FILES[@]} > 0 )); then
  for solution in "${SOLUTION_FILES[@]}"; do
    echo
    echo "== Restore: $solution =="
    dotnet restore "$solution"

    echo
    echo "== Build: $solution =="
    dotnet build "$solution" --no-restore
  done
else
  echo
  echo "AVISO: nenhuma solução .sln/.slnx encontrada; restaurando e compilando cada projeto."

  for project in "${PROJECT_FILES[@]}"; do
    echo
    echo "== Restore: $project =="
    dotnet restore "$project"
  done

  for project in "${PROJECT_FILES[@]}"; do
    echo
    echo "== Build: $project =="
    dotnet build "$project" --no-restore
  done
fi

echo
echo "== Testes =="

if (( ${#TEST_PROJECTS[@]} == 0 )); then
  echo "AVISO: nenhum projeto de testes identificado por IsTestProject ou Microsoft.NET.Test.Sdk."
  echo "Testes não executados; isso não comprova ausência de testes no repositório."
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
  echo "AVISO: diretório não está em um repositório Git; verificação Git ignorada."
fi

echo
echo "Validação básica concluída."
