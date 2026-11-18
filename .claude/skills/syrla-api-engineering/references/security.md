# Segurança da Syrla API

## Mecanismos observados

- JWT Bearer Authentication.
- BCrypt para hash e verificação de senhas.
- Claims: NameIdentifier, Name, Email e Role.
- Roles observadas: `User` e `Admin`.
- Policy `CanManageUsers`, exigindo role `Admin`.
- `GET /api/Auth/me` exige autenticação.
- `GET /api/Auth/admin` exige policy administrativa.
- `GET /api/User` exige autenticação.
- Middleware global de exceções.

## Regras

1. Nunca armazenar ou comparar senhas em texto puro.
2. Nunca retornar `PasswordHash`.
3. Não aceitar role ou permissões definidas livremente pelo cliente durante cadastro.
4. Validar autorização no servidor em cada operação protegida.
5. Não tratar um JWT válido como prova de autorização para qualquer recurso.
6. Não registrar senha, token JWT, segredo de assinatura, connection string ou cabeçalhos Authorization.
7. Manter TLS e validação de certificados.
8. Avaliar rate limiting para login e cadastro, mensagens de erro e prevenção de enumeração de contas.
9. Avaliar expiração, issuer, audience, rotação de segredo e revogação/refresh token conforme necessidade.
10. Não reduzir controles de segurança para fazer um teste passar.

## Pontos identificados para revisão

- O trecho consultado de `UserController` não protege `POST /api/User` com `[Authorize]`. Confirmar se o cadastro público é requisito. Se for público, avaliar validação, rate limiting, abuso automatizado e fluxo de criação de usuário privilegiado.
- A configuração JWT observada valida lifetime e signing key, mas não valida issuer/audience. Avaliar uma configuração explícita de issuer/audience antes de habilitar essas validações.
- O segredo JWT é lido de `JwtSettings:SecretKey`; confirmar que o valor real vem de secret store/variável de ambiente e não está versionado.
- Revisar logs para evitar dados pessoais excessivos; e-mail pode ser dado pessoal e deve ter finalidade/retention definidos.
- Confirmar proteção de endpoints administrativos e recursos por propriedade/tenant quando surgirem dados multiempresa.

## Processo para mudanças de segurança

Descrever:
- ativo e fronteira afetados;
- ameaça e cenário de abuso;
- evidência no código;
- impacto e severidade;
- correção proposta;
- riscos de regressão;
- testes positivos e negativos.

Não afirmar conformidade, segurança corporativa ou ausência de vulnerabilidades sem avaliação adequada.