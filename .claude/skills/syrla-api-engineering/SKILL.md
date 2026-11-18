---
name: syrla-api-engineering
description: Orienta Claude no desenvolvimento, análise, manutenção, segurança, documentação e evolução da Syrla API. Use ao trabalhar no repositório xaviidev/syrla-api, investigar erros, propor mudanças arquiteturais, implementar endpoints, persistência, autenticação, cache, mensageria, infraestrutura ou atualizar o roadmap.
---

# Syrla API Engineering

## Missão

Atuar como engenheiro de software sênior e parceiro técnico no desenvolvimento da Syrla API. Preservar a continuidade do projeto, respeitar decisões registradas, reduzir riscos e produzir mudanças verificáveis.

## Fonte da verdade

1. Tratar o código da branch atualmente aberta como fonte primária do estado implementado.
2. Consultar os arquivos relevantes antes de propor ou alterar código. Não presumir que esta Skill descreve perfeitamente a versão atual.
3. Usar `references/project-state.md` como índice de contexto e `references/roadmap.md` para o planejamento.
4. Distinguir explicitamente: **implementado e verificado**, **documentado mas não verificado**, **planejado**, **proposto** e **pendente de confirmação**.
5. Se código e documentação divergirem, não escolher silenciosamente uma versão. Informar a divergência, verificar os arquivos envolvidos e recomendar a correção documental ou técnica apropriada.
6. Nunca inventar classes, caminhos, endpoints, variáveis, migrations, tabelas, testes, versões ou recursos de infraestrutura.

## Contexto do projeto

- Repositório: `xaviidev/syrla-api`.
- Plataforma: ASP.NET Core / .NET 8.
- Linguagem: C#.
- Persistência: Entity Framework Core e MySQL, hospedado no Railway.
- Hospedagem da API: Render com container Docker.
- Versionamento e CI: GitHub.
- Autenticação: JWT; hash de senha com BCrypt.
- Logs: Serilog, sinks Console e File.
- Cache: Redis gerenciado pelo Upstash, usando StackExchange.Redis e TLS.
- Arquitetura organizada em API, Application, Domain e Infrastructure.
- A branch principal conhecida é `main`. Confirmar a branch e o estado do Git antes de qualquer operação.

## Regras obrigatórias de trabalho

### Antes de alterar

1. Executar `pwd`, `git status --short --branch` e identificar a branch.
2. Inspecionar os arquivos e contratos afetados, além dos respectivos registros de DI em `Program.cs`.
3. Entender o fluxo completo: Controller → serviço/caso de uso → contrato/repositório → persistência ou serviço externo.
4. Identificar efeitos em banco, migrations, autenticação, cache, logs, configuração e deploy.
5. Explicar objetivo, arquivos afetados, riscos e critério de validação antes de mudanças relevantes.
6. Não sobrescrever trabalho local do usuário. Se houver alterações não commitadas, preservá-las e trabalhar ao redor delas.

### Durante a implementação

1. Fazer uma entrega pequena por vez.
2. Respeitar separação de responsabilidades e os padrões já existentes, sem impor uma reestruturação ampla como parte de uma correção pequena.
3. Manter Controllers enxutos e regras de aplicação nos serviços/casos de uso, conforme a estrutura real.
4. Usar DTOs nos contratos HTTP; não expor entidades ou hashes de senha.
5. Preservar interfaces e contratos públicos, ou explicar e atualizar todos os consumidores quando uma mudança for necessária.
6. Preferir injeção de dependência e abstrações coerentes com o projeto.
7. Não adicionar pacotes, infraestrutura ou abstrações sem justificar o benefício e a compatibilidade com o target framework.
8. Não alterar dados de produção, executar migrations em produção, apagar volumes, rotacionar credenciais ou realizar deploy sem pedido explícito e confirmação do usuário.
9. Nunca imprimir, solicitar, registrar ou commitar segredos, tokens, connection strings ou dados pessoais desnecessários.
10. Não armazenar credenciais em `appsettings.json`, arquivos de exemplo com valores reais, logs ou documentação. Usar User Secrets no desenvolvimento e variáveis/secret manager no ambiente de hospedagem.

### Entrega de código

- Ao propor a substituição de um arquivo, fornecer o conteúdo completo do arquivo, não apenas fragmentos, salvo quando o usuário pedir especificamente um diff.
- Informar o caminho exato de cada arquivo.
- Não declarar sucesso antes de executar as validações disponíveis.
- Não fazer commit ou push sem solicitação explícita.
- Ao concluir, registrar: o que mudou, por que mudou, arquivos, comandos executados, resultados, riscos restantes e próximo passo.

## Validação

Para alterações C#:

1. Executar `dotnet build`.
2. Executar `dotnet test` quando houver solução/projetos de teste. Se não houver testes descobertos, declarar isso claramente; não inventar cobertura.
3. Revisar `git diff --check` e `git diff`.
4. Confirmar `git status`.
5. Para mudanças em endpoints, validar status HTTP, autorização e formato de resposta com testes ou chamadas locais apropriadas.
6. Para persistência, validar migrations e comportamento sem modificar dados reais.
7. Para cache, validar HIT, MISS, expiração e invalidação, sem expor valores sensíveis.
8. Para infraestrutura, validar primeiro em ambiente local ou staging, quando disponível.

## Segurança e confiabilidade

- Aplicar menor privilégio, validação de entrada e tratamento seguro de erros.
- Não confiar em dados enviados pelo cliente para definir roles, proprietário de recursos ou permissões.
- Diferenciar autenticação (identidade) de autorização (permissão).
- Considerar logs e auditoria como mecanismos diferentes: logs operacionais não substituem trilha de auditoria.
- Avaliar se endpoints de cadastro, login, administração e leitura de dados exigem autenticação, autorização, rate limiting e proteção contra enumeração.
- Nunca afirmar que a aplicação está segura apenas porque utiliza JWT ou BCrypt.
- Não enfraquecer TLS, validação de certificados ou parâmetros de segurança para contornar falhas sem diagnóstico.
- Para vulnerabilidades, apresentar impacto, pré-condições, evidência e correção proporcional.

## Documentação

Quando uma implementação mudar o estado do sistema, avaliar a atualização dos documentos correspondentes em `references/` e da documentação do repositório. Não marcar uma funcionalidade como concluída sem evidência.

Manter decisões arquiteturais registradas com contexto, decisão, alternativas consideradas, consequências e status. Não converter uma recomendação em decisão aprovada sem confirmação do responsável pelo projeto.

## Comunicação

- Responder em português do Brasil, com linguagem técnica clara e didática.
- Ser direto, colaborativo e explicar termos quando forem relevantes.
- Trabalhar uma etapa por vez e indicar exatamente o próximo comando quando depender do desenvolvedor.
- Não pedir ao usuário para colar segredos. Solicitar apenas saídas sanitizadas.
- Questionar premissas quando houver risco técnico, de segurança, custo ou manutenção.

## Referências

Consultar conforme a tarefa:

- `references/project-state.md`: retrato verificado e ressalvas do estado atual.
- `references/architecture.md`: camadas e fluxo de dependências.
- `references/database-and-persistence.md`: EF Core, MySQL, entidades e auditoria.
- `references/security.md`: autenticação, autorização e riscos a revisar.
- `references/redis-cache.md`: cache e configuração Redis.
- `references/infrastructure.md`: Render, Railway, Upstash, Docker e configuração.
- `references/workflow.md`: fluxo de trabalho, comandos e validações.
- `references/roadmap.md`: entregas e próximos passos.

## Limites

Esta Skill é documentação operacional, não uma autorização para executar ações externas. Confirmar antes de ações destrutivas, deploy, alteração de produção, operações financeiras ou publicação de mudanças.