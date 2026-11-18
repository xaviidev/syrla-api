# Fluxo de trabalho de desenvolvimento

## Princípios

- Uma entrega por vez.
- Entender antes de alterar.
- Mudança mínima e justificável.
- Arquivos completos ao propor substituição.
- Build/teste antes de concluir.
- Commit e push somente quando solicitados.

## Início de sessão

Executar:
```bash
pwd
git status --short --branch
git log -1 --oneline
```

Confirmar repositório, branch e alterações locais. Nunca descartar alterações não commitadas.

## Inspeção

Para localizar arquivos:
```bash
find . -maxdepth 4 -type f | sort
```

Para pesquisar símbolos:
```bash
grep -RIn --exclude-dir=.git --exclude-dir=bin --exclude-dir=obj "NomeDoSimbolo" .
```

Para ler arquivos, usar ferramentas disponíveis no ambiente e inspecionar os contratos e dependências relacionados.

## Implementação

1. Definir objetivo e critério de aceite.
2. Listar arquivos que serão afetados.
3. Ler os arquivos completos relevantes.
4. Fazer uma alteração coerente e pequena.
5. Revisar o diff.
6. Compilar e testar.
7. Reportar limitações e pendências.

## Validação básica

```bash
dotnet restore
dotnet build
dotnet test
git diff --check
git status --short --branch
```

Executar `dotnet test` se houver solução/projeto de testes. Se não houver, informar que nenhum teste foi executado por ausência de projeto descoberto.

## Git

Antes de commit:
```bash
git diff --stat
git diff
git status
```

Nunca usar `git add .` sem revisar o que será incluído. Preferir adicionar caminhos específicos. Não commitar logs, secrets, arquivos temporários, artefatos de build ou dados locais.

Commits devem descrever a mudança de forma objetiva. Push apenas após solicitação do responsável.

## Diagnóstico de produção

- Começar por logs e métricas disponíveis.
- Usar consultas de leitura.
- Não copiar tokens, senhas, e-mails de usuários ou connection strings para a conversa.
- Não executar migrations, DELETE, UPDATE, DROP, flush Redis, reinicialização destrutiva ou limpeza de volumes sem autorização explícita.
- Produzir hipótese, evidência, teste seguro, diagnóstico e plano de correção.

## Conclusão de entrega

Registrar:
- objetivo;
- arquivos alterados;
- comportamento implementado;
- comandos executados e resultados;
- testes não executados e motivo;
- riscos e follow-ups;
- estado Git (sem afirmar commit/push se não ocorreu).