# phnds-processos

projeto roda com o banco sqlserver abaixo o bash pronto para criar e rodar o container.

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MinhaSenhaForte123!" -p 1433:1433 --name sqlserver-projeto -d mcr.microsoft.com/mssql/server:2022-latest
```
O projeto possui um auth controle ce acesso bem básico já.

aqui um sql com alguns usuarios.

```sql
INSERT INTO processos.dbo.Usuarios
(Nome, Email, Senha, Tipo, Code, CriadoEm, AtualizadoEm, ApagadoEm, Apagado)
VALUES
('João Silva', 'joao.silva@email.com', CONVERT(varbinary(50), '1234'), 1, NEWID(), GETDATE(), GETDATE(), NULL, 0),

('Maria Oliveira', 'maria.oliveira@email.com', CONVERT(varbinary(50), '1234'), 2, NEWID(), GETDATE(), GETDATE(), NULL, 0),

('Carlos Souza', 'carlos.souza@email.com', CONVERT(varbinary(50), '1234'), 4, NEWID(), GETDATE(), GETDATE(), NULL, 0);
```
