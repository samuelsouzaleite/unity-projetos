# Unity — Jogo 2D (Start GameDev)

Jogo 2D top-down de fazenda e aventura desenvolvido em **Unity** como projeto de estudo de desenvolvimento de jogos. Inspirado em títulos como *Stardew Valley*, o jogo mistura mecânicas de coleta de recursos, agricultura, pesca e combate.

> Projeto de aprendizado — o código foi escrito acompanhando estudos de Game Dev, então há também scripts de exercícios (pasta `Estudy`) usados para praticar lógica de programação em C#.

## 🎮 Sobre o jogo

O jogador controla um personagem em um mundo 2D com visão de cima, onde pode explorar o cenário, interagir com objetos e enfrentar inimigos. As principais mecânicas implementadas são:

- **Movimentação** — andar, correr e rolar (dash), com animações direcionais.
- **Coleta de recursos** — cortar árvores (com machado) para obter madeira.
- **Agricultura (Farm)** — cavar, plantar e regar plantações (ex.: cenoura).
- **Pesca** — sistema de pesca com chance percentual de fisgar um peixe.
- **Combate** — inimigos (esqueletos) que perseguem o jogador usando *NavMesh*, com barra de vida.
- **Inventário / HUD** — barras de itens (água, madeira, cenoura, peixe) e seleção de ferramentas (machado, pá, balde).
- **NPCs e diálogos** — sistema de diálogo para conversar com personagens.
- **Menu e áudio** — menu principal, controle de música (BGM) e efeitos sonoros (SFX), com botão de ligar/desligar som.

## 🕹️ Controles

| Ação | Tecla |
|------|-------|
| Mover | Setas / WASD |
| Correr | Shift |
| Rolar (dash) | Espaço |
| Interagir / usar ferramenta | E |

> Os controles podem variar conforme ajustes no projeto — consulte os scripts em `Assets/Scripts` para o mapeamento exato.

## 🛠️ Tecnologias

- **Engine:** Unity `2022.3.22f1` (LTS)
- **Linguagem:** C#
- **Recursos:** NavMesh (IA de inimigos), TextMesh Pro (UI), Animator, sistema de partículas
- **Assets visuais:** *Sunnyside World* (tileset e personagens em pixel art)

## 📁 Estrutura do projeto

```
Start GameDev/
├── Assets/
│   ├── Scripts/        # Código C# do jogo
│   │   ├── Buildings/  # Construções (casa)
│   │   ├── Craft/      # Coleta (árvore)
│   │   ├── Dialogue/   # Sistema de diálogo
│   │   ├── Drops Items/ # Itens dropados (madeira, peixe)
│   │   ├── Enemy/      # Inimigos (esqueleto + IA)
│   │   ├── Farm/       # Agricultura, água e pesca
│   │   ├── HUD/        # Interface do jogador
│   │   ├── Npc/        # NPCs
│   │   ├── Sounds/     # Controle de áudio
│   │   └── Estudy/     # Exercícios de estudo em C#
│   ├── Scenes/         # Cenas (MainMenu, FirstScene)
│   ├── Sprites/        # Sprites e tilesets
│   ├── Animation/      # Animações
│   ├── Prefabs/        # Prefabs
│   ├── Sounds/         # Músicas e efeitos sonoros
│   └── UI/             # Elementos de interface
├── Packages/
└── ProjectSettings/
```

## Como executar

1. Instale o **Unity Hub** e a versão **2022.3.22f1** da Unity.
2. Clone este repositório:
   ```bash
   git clone https://github.com/samuelsouzaleite/unity-projetos.git
   ```
3. No Unity Hub, clique em **Add** e selecione a pasta `Start GameDev`.
4. Abra o projeto e carregue a cena `Assets/Scenes/MainMenu.unity`.
5. Pressione **Play** para jogar dentro do editor.

## Status

Projeto em desenvolvimento contínuo, usado como estudo prático de desenvolvimento de jogos 2D na Unity.
