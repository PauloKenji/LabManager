# Gerenciador de laboratórios

Aplicação dotnet console para controle do banco de dados sobre os laboratórios e computadores da escola

## Funcionalidades

- Cria um banco da dados com as tabelas necessárias
- Adiciona registros de computadores e laboratórios
- Lista as informações dos computadores e os laboratórios
    
## Tecnologias

- dotnet core 6.0

## Como Executar
    
Fazer o clone do repositório e executar o comando: 

```
dotnet run -- (Computer ou Laboratory) (List ou New)
```

Se for o comando New deve se incluir os dados necessários:

```
dotnet run -- Computer New (id) (ram) (processador)

dotnet run -- Laboratory New (id) (Numero) (Nome) (Bloco)
```