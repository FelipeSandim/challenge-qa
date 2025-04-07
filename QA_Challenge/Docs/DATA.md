# DATA.md

## Estratégia de Massa de Dados para Testes Automatizados

### Dados para testes E2E
- Os dados de teste devem ser criados dinamicamente ou mockados para garantir isolamento entre execuções.
- Pode-se utilizar builders ou objetos padrão com variações para cenários positivos e negativos.
- A base de dados idealmente deve ser resetada antes de cada execução automatizada, garantindo ambiente limpo.

### Banco PostgreSQL (futuro)
- Utilizar migrations ou scripts SQL para popular tabelas com dados necessários.
- Incluir comandos de limpeza no teardown dos testes (ex: `TRUNCATE`, `DELETE`, etc.).
- Considerar utilizar containers (Docker) com banco de dados preparado para execução isolada dos testes.

### Geração de usuários
- Para cenários com muitos usuários, gerar dados dinâmicos (ex: CPF aleatório, nome aleatório, etc.) com Faker.


## Cenários cobertos:
- Cadastro com dados válidos
- Validação de campos obrigatórios
- Login com credenciais válidas e inválidas
