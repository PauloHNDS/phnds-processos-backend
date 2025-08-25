# phnds-processos

projeto roda com o banco sqlserver abaixo o bash pronto para criar e rodar o container.

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MinhaSenhaForte123!" -p 1433:1433 --name sqlserver-projeto -d mcr.microsoft.com/mssql/server:2022-latest
```
O projeto possui um auth controle ce acesso bem básico já.

aqui um sql com alguns usuarios, para não abstrair muito do foco não adicionei a parte de gerenciamento de usuario.

```sql
INSERT INTO processos.dbo.Usuarios
(Nome, Email, Senha, Tipo, Code, CriadoEm, AtualizadoEm, ApagadoEm, Apagado)
VALUES
('João Silva', 'joao.silva@email.com', CONVERT(varbinary(50), '1234'), 1, NEWID(), GETDATE(), GETDATE(), NULL, 0),

('Maria Oliveira', 'maria.oliveira@email.com', CONVERT(varbinary(50), '1234'), 2, NEWID(), GETDATE(), GETDATE(), NULL, 0),

('Carlos Souza', 'carlos.souza@email.com', CONVERT(varbinary(50), '1234'), 4, NEWID(), GETDATE(), GETDATE(), NULL, 0);
```
comando para rodar a migrations lembrando que é necessario está na pasta da sln, não dentro do api, pois as configs do entity framework estão em um lib separada no caso a data.ef

caso for rodar pelo terminal necessario está instalado o entityframework tools para rodar a migrations, recomando utilizar o tools pelo terminal, por experiencias passadas, acredito que acaba gerando menos problemas.

```bash
dotnet ef database update   --project phnds-processos.data.ef   --startup-project phnds-processos.api
````
Pode ser a versão 9.0.8 do tools
