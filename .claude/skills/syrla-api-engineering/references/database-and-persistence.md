# Banco de dados e persistência

## Tecnologias observadas

- Entity Framework Core.
- MySQL.
- `AppDbContext` em `Infrastructure/Data/AppDbContext.cs`.
- Migrations do EF Core.
- Railway como hospedagem do MySQL, conforme documentação e histórico do projeto.

## DbContext observado

O `AppDbContext` expõe:
- `DbSet<User> Users`
- `DbSet<AuditLog> AuditLogs`

## Entidade User observada

Propriedades:
- `Id` (int)
- `Name` (string)
- `Email` (string)
- `PasswordHash` (string)
- `Role` (string, padrão `User`)

## Entidade AuditLog observada

Propriedades:
- `Id` (int)
- `UserId` (int?).
- `Action` (string)
- `CreatedAt` (DateTime, inicializado com UTC).

## Regras de persistência

1. Inspecionar entidade, DbContext, configuração EF e migrations antes de alterar esquema.
2. Não editar migrations já aplicadas para corrigir o estado atual; criar migration nova quando apropriado.
3. Não executar migrations contra produção sem autorização explícita, plano de rollback e confirmação do alvo.
4. Nunca incluir dados reais ou credenciais em scripts versionados.
5. Considerar índices e unicidade de e-mail, integridade referencial, concorrência e transações ao propor mudanças.
6. Avaliar a operação completa de escrita, inclusive criação de AuditLog e invalidação de cache.
7. Não assumir que o schema do banco remoto corresponde ao último código; confirmar migration history e schema com consulta somente leitura.

## Operações observadas

- `AuthService.LoginAsync`: busca usuário por e-mail, verifica BCrypt, grava AuditLog e emite JWT.
- `UserService.CreateUserAsync`: cria usuário com role `User`, persiste, grava AuditLog e invalida cache `users:all`.
- `UserService.GetUsersAsync`: consulta cache; em MISS consulta repositório, mapeia para `UserResponseDto` e armazena por cinco minutos.

## Ponto de atenção

As gravações do usuário e do registro de auditoria aparecem como operações separadas no serviço. Avaliar transação se a consistência atômica for requisito. Não alterar sem compreender o comportamento do repositório e do banco.