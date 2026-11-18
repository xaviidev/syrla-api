# Syrla API Engineering Skill

Skill de engenharia para manter continuidade técnica ao trabalhar no repositório `xaviidev/syrla-api`.

## Uso com Claude Code

A Skill está no caminho de projeto reconhecido pelo Claude Code:

`.claude/skills/syrla-api-engineering/SKILL.md`

Depois de trazer esta branch para o seu clone local, abra o Claude Code na raiz do repositório. A Skill poderá ser acionada automaticamente quando o pedido corresponder à descrição ou diretamente pelo comando:

`/syrla-api-engineering`

Para conferir as Skills carregadas, use `/skills`.

## Conteúdo

- `SKILL.md`: instruções centrais, fluxo de trabalho, segurança e validação.
- `references/`: contexto de arquitetura, estado atual, persistência, segurança, Redis, infraestrutura, roadmap e workflow.
- `scripts/validate-project.sh`: validação local básica com restore, build, descoberta simples de projetos de teste e Git diff check.

## Instalação

Na raiz do repositório:

```bash
git fetch origin
git checkout docs/claude-syrla-api-skill-v1
```

A branch foi criada separadamente da `main` para revisão. Não faça merge até validar o conteúdo e testar a Skill no seu ambiente.

## Validação do script

Na raiz do repositório:

```bash
bash .claude/skills/syrla-api-engineering/scripts/validate-project.sh
```

O script é uma verificação inicial, não substitui testes de integração, testes de segurança ou validação em staging/produção.

## Atualização

Quando a arquitetura ou o código mudar, revise as referências correspondentes. O código da branch ativa prevalece sobre o retrato documental. Registre claramente o que foi implementado, testado, planejado ou ainda precisa de confirmação.

## Segurança

Não inclua credenciais, tokens, connection strings, dumps de produção ou dados pessoais na Skill. Use User Secrets localmente e secret manager/variáveis seguras nos ambientes hospedados.
