# SimpleRabbitMQ
Exemplo simples de uso do servidor de mensageira de código aberto - RabbitMQ


Requisitos:

  * ErLang;
  * RabbitMQ
  
Instalação

Instalar Erlang para Windows.
Link para Download: http://www.erlang.org/download.html
Selecione a versão correspondente ao seu sistema operacional: OTP 32Bit Binary File ou OTP 64Bit Binary File.

Instalar o RabbitMQ para Windows
Link para Download: http://www.rabbitmq.com/download.html
Após a instalação do RabbitMQ localize o Command Prompt do RabbitMQ, lembre-se de executar como administrador.

No prompt de comando execute o seguinte comando:
rabbitmq-plugins enable rabbitmq_management

Após isso abra o seu navegador e acesse a seguinte url:
http://localhost:15672
Você será solicitado para inserir usuário e senha:
User: guest
Password: guest
