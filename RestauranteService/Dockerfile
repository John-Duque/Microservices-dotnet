#OBS:Lembre de executar esse comando na pasta do diretorio do projeto que dessa criar um container
#execute o comando abaixo para build da aplicação:
#sudo docker build -t restauranteservice:1.0 .
#Lembrando que aqui estou aplicando o multi-stage utilizando o AS para nomear a primeira etapa com o nome build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

#Essa parte de baixo de codigo irei fazer a otimazacao do meu docker
#Utilizando o que somente e necessario para o projeto 
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
#build sera utilizado para pegar as configuracoes da etapa anterior
#copiando do nosso /app da aonde tudo foi executado que sera utilizado para essa nova imagem que estamos criando
#copiando do nosso /out aonde colocamos todas nossas dll na etapa anterior
#copiando finalmente para . que e do nosso diretorio atual /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "RestauranteService.dll" ]
#OBS:Utilize esse comando abaixo para rodar o que foi gerado
#utilize o -d para que o terminal nao trave 
#sudo docker run -d -p 8081:80 restauranteservice:1.0
#OBS:Passo abaixo cria uma network para ser usada no host
#sudo docker network create --driver bridge restaurante-bridge
#OBS:Passo de cima e so pra criar a rede KKKKKKKK
#sudo docker run --name restaurante-service -d -p 8081:80 --network restaurante-bridge restauranteservice:1.0 .
#OBS:MYSQL
#sudo docker run --name mysql -e MYSQL_ROOT_PASSWORD=root -d --network restaurante-bridge mysql:8.0.33 
