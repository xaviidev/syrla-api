# Syrla - Troubleshooting

## Objetivo

Este documento registra problemas encontrados durante o desenvolvimento da Syrla, suas causas e respectivas soluções.

---

# Build Errors

## Erro

CS1061

### Mensagem

```txt
'IUserRepository' does not contain a definition for 'GetUsersAsync'
```

### Causa

Métodos foram implementados no serviço mas não existiam na interface.

### Solução

Atualizar contratos da interface para refletir a implementação.

---

# Namespace Errors

## Erro

CS0234

### Mensagem

```txt
The type or namespace name could not be found
```

### Causa

Arquivos movidos para novas pastas sem atualização dos namespaces.

### Solução

Revisar namespace e referências utilizando:

```bash
grep -R "NamespaceAntigo" .
```

---

# Migration Errors

## Erro

AppDbContext não encontrado

### Causa

Refatoração da estrutura sem atualização dos arquivos de migration.

### Solução

Corrigir namespaces e validar referências do DbContext.

---

# UserService Errors

## Erro

CS0106

### Mensagem

```txt
The modifier 'public' is not valid for this item
```

### Causa

Métodos colados fora da classe UserService.

### Solução

Reconstruir a estrutura correta da classe.

---

# JWT Errors

## Problema

JwtSettings localizado em pasta incorreta.

### Estrutura antiga

```txt
Auth/JwtSettings.cs
```

### Estrutura correta

```txt
Infrastructure/Authentication/JwtSettings.cs
```

### Solução

Mover arquivo e atualizar namespace.

---

# Test Errors

## Problema

ReturnsAsync incompatível.

### Causa

SaveChangesAsync retornava Task e não Task<int>.

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

# Boas Práticas

## Sempre executar

```bash
dotnet build
```

após qualquer alteração estrutural.

---

## Sempre executar

```bash
dotnet test
```

antes de commits importantes.

---

## Nunca

* Mover múltiplas camadas simultaneamente.
* Refatorar sem validar build.
* Alterar namespaces sem revisão.

---

# Comandos Úteis

Verificar estrutura:

```bash
find . -maxdepth 3 -type d | sort
```

Verificar referências:

```bash
grep -R "NomeClasse" .
```

Executar build:

```bash
dotnet build
```

Executar testes:

```bash
dotnet test
```
