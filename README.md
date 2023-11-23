# Desafio Quiz

Este arquivo README fornece informações detalhadas sobre o desenvolvimento do jogo de quiz. O jogo incorpora o uso de Scriptable Objects, Particle System, efeitos sonoros e padrões de design Singleton e Observer.

![Figma](https://res.cloudinary.com/renanrider/image/upload/v1700680371/figma_h3g9i9.png)

## Desenvolvimento Geral

O jogo de quiz foi desenvolvido no Unity, aproveitando as funcionalidades poderosas da engine para criar uma experiência interativa e envolvente.

### Scriptable Objects

**Decisões:**
- Uso de Scriptable Objects para armazenar dados estáticos, como perguntas, respostas e resposta correta. Isso permite fácil extensibilidade e reutilização de dados sem a necessidade de modificar diretamente os scripts.
- Cada pergunta é um Scriptable Object, facilitando a criação e gerenciamento de diferentes conjuntos de perguntas.

**Implementação:**
1. Criei uma classe `QuestionData` que herda de `ScriptableObject` para representar dados de pergunta.
2. Cada `QuestionData` possui campos para a pergunta, opções de resposta e a resposta correta.

### Particle System

**Decisões:**
- Uso de Particle System para adicionar efeitos visuais dinâmicos ao jogo, como explosões de confete quando o jogador responde corretamente.
- Isso adiciona uma camada extra de imersão e feedback visual ao jogo.

**Implementação:**
1. Criei uma classe responsável por disparar  partículas de confete para adicionar mais engajamento ao quiz.

### Efeitos Sonoros

**Decisões:**
- Uso de efeitos sonoros para aumentar a experiência audiovisual do jogo.
- Efeitos sonoros são usados para feedback imediato ao selecionar respostas corretas ou incorretas, incentivando a interatividade.

**Implementação:**
1. Criei uma classe SoundManager responsável por executar os áudios de click, sucesso e falha.
2. Uso da API de áudio do Unity para reproduzir os efeitos sonoros em momentos estratégicos do jogo.

## Padrões de Design

### Singleton Pattern

**Decisões:**
- Uso do padrão Singleton para garantir que exista apenas uma instância dos `Managers` em execução, garantindo o gerenciamento centralizado do estado do jogo.

**Implementação:**
1. Criei classes de `Managers` que seguem o padrão Singleton.
2. O UIManager gerencia o estado geral dos painéis, como pontuação do jogador e controle de fluxo.

### Observer Design Pattern

**Decisões:**
- Uso do padrão Observer Design Pattern no `EventManager` para facilitar a comunicação entre diferentes partes do jogo sem criar acoplamentos diretos.

**Implementação:**
1. Foi criado uma classe `EventManager` que permite que diferentes partes do código se inscrevam e recebam notificações de eventos específicos.
2. Componentes interessados (observadores) se registram para receber notificações sobre eventos relevantes, como respostas corretas ou incorretas.

## Conclusão

O jogo de quiz foi desenvolvido com êxito, incorporando Scriptable Objects, Particle System, efeitos sonoros e padrões de design Singleton e Observer. Essas escolhas de design contribuíram para um código modular, reutilizável e uma experiência de jogo mais envolvente para os jogadores.
