# Fluxo de trabalho de desenvolvimento

## Princípios

- Uma entrega por vez.
- Entender antes de alterar.
- Mudança mínima e justificável.
- Arquivos completos ao propor substituição.
- Build/teste antes de concluir, quando o ambiente permitir.
- Commit e push somente quando solicitados.
- Não confundir análise documental com execução ou validação técnica.

## Diferenças entre ambientes

### Claude Web

- Consultar os arquivos efetivamente disponibilizados no Project e registrar limitações de atualização/sincronização.
- Não afirmar que executou terminal, Bash, Git local, restore, build, testes ou scripts sem ferramenta de execução e saída observável.
- Quando não houver ambiente de execução, fornecer o comando exato para o desenvolvedor executar em ambiente autorizado e solicitar somente a saída sanitizada.
- Se houver ferramenta de edição GitHub, conferir branch, conteúdo atual e diff antes de gravar; não presumir que a conexão de leitura do Project permite escrita.
- A Skill instalada por upload no Claude Web precisa ser atualizada separadamente quando o arquivo `SKILL.md` mudar no GitHub.

### Claude Code

- Confirmar que o Claude Code foi iniciado na raiz do clone correto.
- Verificar branch, estado local e ferramentas instaladas antes de executar comandos.
- Não sobrescrever alterações locais do usuário.
- Executar comandos apenas após entender seu escopo e efeitos.

## Início de sessão

Quando houver terminal local, executar:

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

Ler os arquivos completos relevantes e inspecionar contratos, dependências, chamadas e registros de DI relacionados.

## Implementação

1. Definir objetivo e critério de aceite.
2. Listar arquivos que serão afetados.
3. Ler os arquivos completos relevantes.
4. Fazer uma alteração coerente e pequena.
5. Revisar o diff.
6. Compilar e testar, quando houver ambiente local.
7. Reportar limitações e pendências sem declarar validações não executadas.

## Validação local

Na raiz do repositório:

```bash
dotnet restore
dotnet build
dotnet test
git diff --check
git status --short --branch
```

Executar testes quando houver solução/projeto de testes. Se nenhum projeto de teste for identificado, informar isso claramente; não declarar cobertura inexistente. O script `scripts/validate-project.sh` automatiza uma verificação básica, mas sua saída deve ser examinada e não substitui testes de integração, segurança ou staging.

## Git

Antes de commit:

```bash
git diff --stat
git diff
git status
```

Nunca usar `git add .` sem revisar o que será incluído. Preferir adicionar caminhos específicos. Não commitar logs, secrets, arquivos temporários, artefatos de build ou dados locais.

Commits devem descrever a mudança de forma objetiva. Commit, push, PR, merge e publicação são operações distintas; não presumir autorização para uma etapa porque outra foi autorizada.

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
