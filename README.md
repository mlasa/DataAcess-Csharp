## ~ Contextualização
**Como o projeto está organizado?**

- Carreira: é um caminho que um aluno pode escolher
- Items da carreira: São os passos que o aluno deve seguir dentro de uma carreira
- Curso: É o curso que está dentro de um passo da carreira (item da carreira)
- Categoria: Categoria de um curso, ou artigo, vídeo.

Exemplo:
* Cursos: HTML e CSS, Aprenda JavaScript, Entenda OO
* Carreira (Carreer): Frontend.
* Items de carreira (CarreerItem):
    - {
        - Título: Comece por aqui.
        - Descrição: Base é fundamental para poder evoluir.
        - Curso: HTML e CSS
          
    },
   - {
        - Título: Dando um passo a mais.
        - Descrição: Torne suas interfaces dinâmicas, e faça requisições de dados
        - Curso: Aprenda JavaScript
          
    }
* Categorias: Frontend

<br /><br />


## ~ Essa é uma consulta One to One, que busca Item de uma carreira e seu curso relacionado, e filtra a busca pelo id do curso. ~

Tenho uma estrutura onde tenho **ITEM DE CARREIRA** e essa classe possui algumas propriedades, descrição, título, e curso.
Oque mais interessa é **CURSO** pois é um outro objeto que está relacionado. E um **ITEM DE CARREIRA** só pode possuir um único **CURSO**.

Para encontrar um **CURSO** específico e seu **ITEM DE CARREIRA** relacionado fiz uma consulta na tabela CarreerItem buscando onde a chave estrangeira de curso era igual ao que eu buscava, pois não quero todos os items de carreira, quero de um curso específico.
Fiz um join, para que todos os dados do curso fossem trazidos junto.
E por fim fiz o mapeamento, colocando Curso, dentro de CarreerItem.
![Screenshot](onetoone_by_course.png)
