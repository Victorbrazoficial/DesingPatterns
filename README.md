# Design Patterns
Design patterns são soluções reutilizáveis e comprovadas para problemas comuns de design de software. Eles ajudam a melhorar a qualidade do software e facilitar a comunicação entre desenvolvedores. Existem três tipos principais de design patterns: padrões de criação, padrões de estrutura e padrões comportamentais.

# Sobre o projeto

Meu projeto é uma API que visa implementar diversos padrões de design, como Chain of Responsibility, Strategy, Template Method, entre outros, com o objetivo de aprimorar minhas habilidades em boas práticas de programação e arquitetura de software. Utilizando a arquitetura limpa e os princípios SOLID, busco criar um código mais organizado e sustentável, enquanto testes unitários garantem a qualidade do software. Com essa abordagem, busco criar uma API escalável, facilmente mantida e adaptável a futuras mudanças, que possa ser uma contribuição valiosa para a equipe de desenvolvimento de software da sua empresa.

## Back-end do Projeto
![image](https://user-images.githubusercontent.com/87781300/235450099-855cae30-bf56-4959-9bc9-eb4e6fa743fe.png)

## Features
### Strategy
- Implementamos o padrão Strategy para gerenciar diferentes tipos de impostos em nosso projeto, substituindo uma implementação anterior baseada em if. Agora, o código é mais modular, flexível e fácil de manter.

O padrão Strategy é muito útil quando temos um conjunto de algoritmos similares, e precisamos alternar entre eles em diferentes pedaços da aplicação. No exemplo do código, temos diferentes maneira de calcular o imposto, e precisamos alternar entre elas.

O Strategy nos oferece uma maneira flexível para escrever diversos algoritmos diferentes, e de passar esses algoritmos para classes clientes que precisam deles. Esses clientes desconhecem qual é o algoritmo "real" que está sendo executado, e apenas manda o algoritmo rodar. Isso faz com que o código da classe cliente fique bastante desacoplado das implementações concretas de algoritmos, possibilitando assim com que esse cliente consiga trabalhar com N diferentes algoritmos sem precisar alterar o seu código.

### Chain of Responsibility
- Implementamos uma funcionalidade em nosso orçamento para conceder descontos de acordo com o tipo da venda. Se um cliente comprar mais de 5 itens ou fizer uma compra casada de produtos, ele receberá descontos específicos, o que aumenta a flexibilidade e a capacidade de atender às necessidades dos clientes.

O padrão Chain of Responsibility cai como uma luva quando temos uma lista de comandos a serem executados de acordo com algum cenário em específico, e sabemos também qual o próximo cenário que deve ser validado, caso o anterior não satisfaça a condição.

Nesses casos, o Chain of Responsibility nos possibilita a separação de responsabilidades em classes pequenas e enxutas, e ainda provê uma maneira flexível e desacoplada de juntar esses comportamentos novamente.
# Tecnologias utilizadas
## Back end
- .Net 6.0/c#
- Asp Net.core
- xUnit
- Insomnia
# Como executar o projeto

## Back end
Pré-requisitos: .net 6.0

```bash
# clonar repositório
git clone https://github.com/devsuperior/sds1-wmazoni

# entrar na pasta do projeto clonado
cd "projeto clonado"

# executar o projeto
.net run
```

# Meu Linkedin

https://www.linkedin.com/in/victor-braz-9bb915162/

