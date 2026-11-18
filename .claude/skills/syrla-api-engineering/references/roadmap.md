# Roadmap da Syrla API

## Status de referência

Este roadmap consolida o histórico de desenvolvimento até a integração Redis. Confirmar cada item no código e ambiente antes de usá-lo como evidência de produção.

### Fundação e API
- ASP.NET Core 8 e estrutura em camadas: concluído conforme histórico.
- DTOs, serviços, repositórios e middleware global: implementados.
- EF Core e MySQL: implementados.
- Deploy Docker/Render e MySQL Railway: implementados conforme documentação/histórico.

### Autenticação e segurança
- Login JWT e BCrypt: implementados.
- Endpoint `GET /api/Auth/me`: implementado.
- Roles `User` e `Admin`: implementadas.
- Policy `CanManageUsers`: implementada.
- Endpoint administrativo protegido: implementado.
- AuditLog para login e criação de usuário: implementado.
- Revisões de segurança pendentes: cadastro público, rate limiting, issuer/audience, estratégia de segredos, refresh/revogação e auditoria mais abrangente.

### Escalabilidade e observabilidade
- Health checks para API e MySQL: implementados.
- Serilog com Console e File: implementado.
- Logs de eventos de login e criação de usuário: implementados.
- Redis Cache: implementado e testado no fluxo de listagem de usuários.
- RabbitMQ: próximo item planejado; não iniciado.
- Background Services: planejado; não iniciado.
- Observabilidade avançada: planejada; não iniciada.
- Health check Redis: não observado no código consultado.

## Próximos passos sugeridos

1. Corrigir e consolidar documentação desatualizada.
2. Configurar User Secrets para desenvolvimento local de Redis e revisar secret management de produção.
3. Revisar pontos de segurança identificados na referência `security.md`.
4. Planejar RabbitMQ: casos de uso, contratos de mensagens, idempotência, retry, dead-letter queue, observabilidade e segurança.
5. Implementar RabbitMQ em uma entrega isolada e testável.
6. Implementar Background Services consumidores.
7. Evoluir health checks e observabilidade.
8. Adicionar/confirmar testes automatizados e pipeline de qualidade.

## Regra de status

Não marcar item como concluído apenas porque aparece neste roadmap. Exigir evidência no código, configuração e/ou teste. Registrar separadamente implementação local, deploy e validação em produção.