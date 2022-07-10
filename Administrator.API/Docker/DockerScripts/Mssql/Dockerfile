FROM mcr.microsoft.com/mssql/server:2019-latest
USER root
RUN apt-get -y update  && \
        apt-get install -y dos2unix
COPY ./ .
 RUN dos2unix *
RUN chmod +x entrypoint.sh
USER mssql
ENTRYPOINT /bin/bash ./entrypoint.sh