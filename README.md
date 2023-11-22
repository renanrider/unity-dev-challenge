# Desafio Quiz

Este arquivo README fornece informações detalhadas sobre o desenvolvimento do jogo de quiz. O jogo incorpora o uso de Scriptable Objects, Particle System, efeitos sonoros e padrões de design Singleton e Observer.

![Figma](https://res.cloudinary.com/renanrider/image/upload/v1700680371/figma_h3g9i9.png)

## Desenvolvimento Geral

O jogo de quiz foi desenvolvido no Unity, aproveitando as funcionalidades poderosas da engine para criar uma experiência interativa e envolvente.

### Scriptable Objects

**Decisões:**
- Utilizamos Scriptable Objects para armazenar dados estáticos, como perguntas, respostas e informações do jogador. Isso permite fácil extensibilidade e reutilização de dados sem a necessidade de modificar diretamente os scripts.
- Cada pergunta é um Scriptable Object, facilitando a criação e gerenciamento de diferentes conjuntos de perguntas.

**Implementação:**
1. Criamos uma classe `QuestionData` que herda de `ScriptableObject` para representar dados de pergunta.
2. Cada `QuestionData` possui campos para a pergunta, opções de resposta e a resposta correta.

### Particle System

**Decisões:**
- Utilizamos o Particle System para adicionar efeitos visuais dinâmicos ao jogo, como explosões de confete quando o jogador responde corretamente.
- Isso adiciona uma camada extra de imersão e feedback visual ao jogo.

**Implementação:**
1. Criamos um sistema de partículas no Unity para representar os efeitos visuais desejados.
2. O Particle System é acionado em eventos específicos, como quando uma resposta correta é selecionada.

### Efeitos Sonoros

**Decisões:**
- Incorporamos efeitos sonoros para aumentar a experiência audiovisual do jogo.
- Efeitos sonoros são usados para feedback imediato ao selecionar respostas corretas ou incorretas, incentivando a interatividade.

**Implementação:**
1. Importamos e configuramos arquivos de áudio no Unity para os efeitos sonoros desejados.
2. Utilizamos o API de áudio do Unity para reproduzir os efeitos sonoros em momentos estratégicos do jogo.

## Padrões de Design

### Singleton Pattern

**Decisões:**
- Utilizamos o padrão Singleton para garantir que exista apenas uma instância dos `Managers` em execução, garantindo o gerenciamento centralizado do estado do jogo.

**Implementação:**
1. Criamos classes de `Managers` que seguem o padrão Singleton.
2. O UIManager gerencia o estado geral dos painéis, como pontuação do jogador e controle de fluxo.

### Observer Design Pattern

**Decisões:**
- Implementamos o Observer Design Pattern no `EventManager` para facilitar a comunicação entre diferentes partes do jogo sem criar acoplamentos diretos.

**Implementação:**
1. Foi criado uma classe `EventManager` que permite que diferentes partes do código se inscrevam e recebam notificações de eventos específicos.
2. Componentes interessados (observadores) se registram para receber notificações sobre eventos relevantes, como respostas corretas ou incorretas.

## Conclusão

O jogo de quiz foi desenvolvido com êxito, incorporando Scriptable Objects, Particle System, efeitos sonoros e padrões de design Singleton e Observer. Essas escolhas de design contribuíram para um código modular, reutilizável e uma experiência de jogo mais envolvente para os jogadores.
