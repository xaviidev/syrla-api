# Syrla API Engineering Skill

Skill de engenharia para manter continuidade técnica ao trabalhar no repositório `xaviidev/syrla-api`.

## Ambientes compatíveis

A Skill pode orientar tanto o Claude Web quanto o Claude Code, mas a execução de tarefas depende das ferramentas disponíveis em cada ambiente.

### Claude Web

1. Adicione o repositório `xaviidev/syrla-api` ao contexto do Project, quando a conexão estiver disponível.
2. Instale a Skill pelo fluxo de gerenciamento de Skills do Claude Web.
3. Use o Project para consultar o contexto documental e a Skill para aplicar a metodologia de engenharia.
4. Não presuma que a conexão do Project permite executar comandos, compilar, testar ou alterar o GitHub.
5. O upload da Skill no Claude Web é uma instalação separada: alterações futuras no repositório não atualizam automaticamente o pacote já instalado. Reenvie a versão atualizada quando a Skill mudar.

O Claude Web não deve declarar que executou scripts, comandos locais, build ou testes sem uma ferramenta de execução e evidência observável.

### Claude Code

A Skill fica no caminho reconhecido pelo Claude Code:

`.claude/skills/syrla-api-engineering/SKILL.md`

Depois de obter a branch em um clone local, abra o Claude Code na raiz do repositório. A Skill poderá ser acionada automaticamente pela descrição ou diretamente pelo comando:

`/syrla-api-engineering`

Para conferir as Skills carregadas, use:

`/skills`

## Conteúdo

- `SKILL.md`: instruções centrais, ambientes, fluxo de trabalho, segurança e validação.
- `references/`: contexto de arquitetura, estado atual, persistência, segurança, Redis, infraestrutura, roadmap e workflow.
- `scripts/validate-project.sh`: validação local com descoberta de projetos, restore, build, testes identificados e Git diff check.

## Instalação da branch no Claude Code

Na raiz do repositório:

```bash
git fetch origin
git checkout docs/claude-syrla-api-skill-v1
```

A branch foi criada separadamente da `main` para revisão. Não faça merge até validar o conteúdo e testar a Skill no ambiente de desenvolvimento.

## Validação local

Na raiz do repositório:

```bash
bash .claude/skills/syrla-api-engineering/scripts/validate-project.sh
```

O script exige Bash, Git (para a verificação de estado, quando aplicável) e .NET SDK compatível com o projeto. Ele pode restaurar pacotes e criar artefatos locais em `obj/` e `bin/`. Não executa migrations, deploy, operações no banco ou alterações remotas.

O script é uma verificação inicial, não substitui testes de integração, testes de segurança ou validação em staging/produção. Se não houver projeto de testes identificado, ele informa que os testes não foram executados.

## Atualização

Quando a arquitetura ou o código mudar, revise as referências correspondentes. O código da branch ativa prevalece sobre o retrato documental. Registre claramente o que foi implementado, testado, planejado ou ainda precisa de confirmação.

Se `SKILL.md` mudar, atualize também a cópia instalada no Claude Web por upload. A sincronização do repositório no Project não deve ser confundida com atualização automática da Skill instalada.

## Segurança

Não inclua credenciais, tokens, connection strings, dumps de produção ou dados pessoais na Skill. Use User Secrets localmente e secret manager/variáveis seguras nos ambientes hospedados.
