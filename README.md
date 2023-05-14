# Granjero Saltador

Mini juego en Unity 3D de tipo _corredor infinito_ en el que el personaje principal debe saltar sobre los obstáculos que aparecen en su camino.

Basado en: [Prototype 3 Run & Jump](https://assetstore.unity.com/packages/templates/tutorials/create-with-code-prototype-3-run-and-jump-146039) de la [Unity Asset Store](https://assetstore.unity.com) que forma parte de los cursos [Unity Learn](https://learn.unity.com/) que la plataforma pone a disposición de la comunidad.

## Movimiento y salto del personaje

El personaje estará situado a la izquierda de la escena y aparentará moverse hacia la derecha.

### Run

Pero su movimiento se hará con una técnica muy empleada en este tipo de juegos que consiste en que el personaje en realidad no se mueve (lo que, de paso, evita tener que mover la cámara), sino que es el fondo el que se mueve en dirección contraria, de derecha a izquierda, en este caso.

Para conseguir el efecto correcto aprovecharemos que la imagen de la que disponemos para el fondo es en realidad una imagen duplicada a lo ancho, de modo que podemos hacer que parezca un movimiento continuo e infinito si la movemos hacia la derecha en el momento y distancia adecuados.

Hay que tener en cuenta que la velocidad del movimiento hacia la izquierda que se aplica al fondo, debe aplicarse al resto de objetos de la escena, así que el movimiento se debe modular en scripts diferentes:

- Uno único para el fondo de escenario infinito.
- Otro común a todos los Game Objects sincronizados con la escena

### Jump

El personaje deberá saltar al pulsar la barra espaciadora con una fuerza de impulso de valor 8, pero sólo si toca firme.

Se aplican las físicas de Rigidbody.
