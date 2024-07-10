FROM mysql:8.0

ENV MYSQL_ROOT_PASSWORD=root_password
ENV MYSQL_DATABASE=nome_do_banco
ENV MYSQL_USER=usuario
ENV MYSQL_PASSWORD=senha

COPY ./Data/script.sql /docker-entrypoint-initdb.d/

EXPOSE 3306
