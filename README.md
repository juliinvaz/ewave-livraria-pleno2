# Processo Seletivo Pleno II - Ewave
## Tecnologias
### Back-End
- .Net Core 3.1
- Swagger
- DDD
- EntityFramework
- UnitOfWork 
- XUnit

### Database
- SQL Server

## Funcionalidades
- ### Instituição de Ensino
    Permite criar, alterar, mudar a situação de um cadastro e consultar. 
- ### Usuario
    Permite criar, alterar, mudar a situação de um cadastro e consultar.
- ### Livro
    Permite criar, alterar, mudar a situação de um cadastro e consultar.
- ### Empréstimo
    Permite criar, devolver um livro e consultar. 
- ### Reserva
    Permite reservar um livro e consultar. 

## Implementações futuras
- Dapper (Evitar os inner desnecessários pelo EF)
- HangFire (Dar aviso sobre atrados para o administrador)
- Criar FrontEnd

# Executar o Projeto
Para executar o projeto, é necessário [docker](https://www.docker.com  "docker") instalado e rodando na sua máquina com containers base em LINUX e portas 1433 e 8000 disponíveis.
```
> git clone https://github.com/juliinvaz/ewave-livraria-pleno2.git
> cd ewave-livraria-pleno2
> docker-compose up
```
Após finalização da execução do docker você pode accessar :
- backend-swagger : clicando [aqui](http://localhost:8000/swagger  "aqui").

 
