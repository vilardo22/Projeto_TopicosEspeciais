<<<<<<< HEAD
# Projeto_TopicosEspeciais
=======
# Projeto_TopicosEspeciais
📘 Sistema de Reserva de Salas
👥 Integrantes

Davi Hugo Dominicki

Gabriel Vilar

Arthur Chrispim Mainardes Ribeiro

Bruno Mazur

Curso: Análise e Desenvolvimento de Sistemas
Turma: 3º semestre

📖 Resumo
O Sistema de Reserva de Salas é uma aplicação backend desenvolvida com o objetivo de gerenciar o agendamento de espaços de forma eficiente e organizada. A solução permite o cadastro de salas e usuários, além da criação de reservas com validação automática de conflitos de horário, evitando sobreposição de agendamentos. O sistema foi construído utilizando tecnologias modernas de desenvolvimento, simulando um ambiente real de aplicação corporativa com integração entre API REST, banco de dados e versionamento de código. Este texto foi elaborado com o auxílio de Inteligência Artificial e posteriormente revisado pela equipe.

⚙️ Funcionalidades
Cadastro de salas

Listagem de salas

Atualização de salas

Remoção de salas

Cadastro de usuários

Listagem de usuários

Criação de reservas

Validação de conflito de horários

Listagem de reservas

Remoção de reservas

🔍 Descrição das Funcionalidades
🏢 Cadastro e Gerenciamento de Salas
Permite registrar novas salas informando nome e capacidade. O sistema também possibilita a listagem de todas as salas cadastradas, além da atualização e exclusão de registros existentes.

👤 Cadastro de Usuários
Permite inserir novos usuários no sistema com informações básicas como nome e e-mail. Também é possível consultar os usuários cadastrados para utilização nas reservas.

📅 Criação de Reservas
Permite que um usuário realize a reserva de uma sala em uma data e intervalo de horário específico. Essa funcionalidade conecta as entidades de usuário e sala, garantindo o relacionamento entre os dados.

⚠️ Validação de Conflitos de Horário
Antes de confirmar uma reserva, o sistema verifica se já existe outro agendamento para a mesma sala no período informado. Caso exista conflito, a reserva não é permitida, garantindo integridade e consistência dos dados.

📋 Listagem e Remoção de Reservas
Permite visualizar todas as reservas realizadas no sistema e também remover reservas existentes quando necessário.

🤖 Uso de IA
Ferramenta utilizada: ChatGPT

Forma de uso:
A ferramenta foi utilizada para auxiliar na construção da documentação do projeto, definição das funcionalidades, estruturação do sistema e geração de exemplos de uso da API. Também foi utilizada para organização das tarefas da equipe e apoio na tomada de decisões técnicas.

🧠 Prompts Utilizados (estruturados)
Prompt 1 – Geração do README:

Gere um README completo para um projeto backend em C# com .NET 8 (Minimal API), contendo:
- Título
- Integrantes
- Curso e turma
- Resumo em um parágrafo
- Funcionalidades em tópicos
- Descrição detalhada das funcionalidades
- Uso de IA com explicação e prompts utilizados 

Prompt 2 – Definição das funcionalidades:

Sugira funcionalidades para um sistema de reserva de salas que não seja apenas CRUD simples, incluindo regras de negócio como validação de conflitos de horário.
Prompt 3 – Estrutura do sistema:

Defina entidades e relacionamentos para um sistema de reservas com banco de dados utilizando Entity Framework e SQLite.

Prompt 4 – Organização do projeto: 

Atue como Product Owner e organize um projeto com equipe de 4 desenvolvedores, definindo tarefas, responsabilidades e fluxo de trabalho com Git.

🔍 Revisões realizadas pela equipe
Ajuste dos nomes das entidades conforme implementação real

Revisão textual para adequação acadêmica

Validação das funcionalidades implementadas

Correção de inconsistências entre documentação e código

🚀 Observação Final
Este projeto foi desenvolvido com foco em simular um ambiente real de desenvolvimento de software, aplicando conceitos de API REST, banco de dados relacional, trabalho em equipe e uso de ferramentas modernas de desenvolvimento.
>>>>>>> feature/fix-dotnet8
