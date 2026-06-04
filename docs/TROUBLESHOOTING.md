# Syrla - Troubleshooting

## Objetivo

Este documento registra problemas encontrados durante o desenvolvimento e implantação da Syrla, suas causas e respectivas soluções.

---

# Erros de Build

## Erro

CS1061

### Mensagem

```txt
'IUserRepository' does not contain a definition for 'GetUsersAsync'
```

### Causa

Métodos foram implementados nos serviços sem atualização da interface correspondente.

### Solução

Atualizar os contratos da interface para refletir a implementação.

---

# Erros de Namespace

## Erro

CS0234

### Mensagem

```txt
The type or namespace name could not be found
```

### Causa

Arquivos movidos entre pastas sem atualização dos namespaces.

### Solução

Revisar namespaces e referências utilizando:

```bash
grep -R "NamespaceAntigo" .
```

---

# Erros de Migration

## Problema

AppDbContext não encontrado.

### Causa

Refatoração da estrutura sem atualização das migrations.

### Solução

Validar:

* Namespaces
* Referências
* Configuração do DbContext

---

# Erros no UserService

## Erro

CS0106

### Mensagem

```txt
The modifier 'public' is not valid for this item
```

### Causa

Métodos adicionados fora da classe UserService.

### Solução

Reconstruir a estrutura correta da classe.

---

# Problemas com JWT

## Problema

JwtSettings localizado em diretório incorreto.

### Estrutura Antiga

```txt
Auth/JwtSettings.cs
```

### Estrutura Correta

```txt
Infrastructure/Authentication/JwtSettings.cs
```

### Solução

Mover o arquivo e atualizar os namespaces.

---

# Problemas em Testes Unitários

## Problema

ReturnsAsync incompatível.

### Causa

SaveChangesAsync retornava:

```csharp
Task
```

e não:

```csharp
Task<int>
```

### Solução

Substituir:

```csharp
ReturnsAsync(1)
```

por:

```csharp
Returns(Task.CompletedTask)
```

---

# Problemas de Git

## Problema

Projeto sem repositório Git configurado.

### Sintoma

```bash
git status
```

retornava:

```txt
fatal: not a git repository
```

### Solução

Inicializar o repositório:

```bash
git init
git add .
git commit -m "initial commit"
```

---

# Problemas de Autenticação GitHub

## Problema

Falha no push utilizando usuário e senha.

### Mensagem

```txt
Password authentication is not supported for Git operations
```

### Solução

Utilizar GitHub CLI:

```bash
gh auth login
```

Após autenticação:

```bash
git push -u origin main
```

---

# Problemas com Oracle Cloud

## Problema

Falha ao criar instância Always Free.

### Mensagem

```txt
Insufficient capacity for VM.Standard.A1.Flex
```

### Causa

Ausência de recursos disponíveis na região selecionada.

### Solução

Adotar temporariamente:

```txt
Render + Railway
```

como infraestrutura principal.

---

# Problemas de Deploy no Render

## Problema

Aplicação publicada mas Swagger indisponível.

### Sintoma

```txt
HTTP 404
```

ao acessar:

```txt
/swagger
```

### Causa

Swagger habilitado apenas em ambiente Development.

### Solução

Habilitar Swagger também em produção.

---

# Problemas de Banco de Dados

## Problema

Erro 500 durante login.

### Causa

Banco de dados em produção não possuía tabelas criadas.

### Solução

Executar migrations:

```bash
dotnet ef database update
```

---

# Problema

Login retornando:

```txt
Credenciais inválidas
```

### Causa

Tabela Users vazia.

### Solução

Cadastrar usuário inicial através do endpoint:

```http
POST /api/User
```

---

# Problemas de Connection String

## Problema

Falha ao carregar appsettings.json

### Causa

Quebra de linha inserida dentro da senha da connection string.

### Exemplo incorreto

```json
"password=senha

"
```

### Solução

Manter a string de conexão em uma única linha.

---

# Problemas de Railway

## Problema

Banco aparentemente conectado mas sem dados.

### Diagnóstico

Verificar:

```sql
SHOW TABLES;
```

### Solução

Executar migrations e validar criação das tabelas:

```txt
Users
__EFMigrationsHistory
```

---

# Problemas de Health Check

## Problema

Endpoint não encontrado.

### Solução

Validar configuração do endpoint:

```http
GET /health
```

e confirmar publicação da versão correta no Render.

---

# Boas Práticas

## Sempre executar

```bash
dotnet build
```

após alterações estruturais.

---

## Sempre executar

```bash
dotnet test
```

antes de commits importantes.

---

## Sempre validar

```bash
git status
```

antes de commits e deploys.

---

## Sempre revisar

* Variáveis de ambiente
* Connection Strings
* Configuração JWT
* Logs do Render

antes de investigar erros mais complexos.

---

# Comandos Úteis

Verificar estrutura:

```bash
find . -maxdepth 3 -type d | sort
```

---

Verificar referências:

```bash
grep -R "NomeClasse" .
```

---

Executar build:

```bash
dotnet build
```

---

Executar testes:

```bash
dotnet test
```

---

Executar migrations:

```bash
dotnet ef database update
```

---

Verificar tabelas:

```sql
SHOW TABLES;
```

---

# Status Atual

```txt
Fase 1 ✅
Fase 2 ✅
Fase 3 ✅
Fase 4 🚀
```
