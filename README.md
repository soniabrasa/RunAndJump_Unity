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

## Espaneo de obstáculos

Crearemos un GameManager que se encargará de ir sembrando de obstáculos el camino de nuestro atlético granjero. Mediante una corrutina, se espaneará una barrera cada cierto tiempo elegido aleatoriamente entre 1 y 4 segundos.

Lógicamente las barreras tienen que correr hacia la izquierda al mismo ritmo que el fondo de pantalla. Deberemos poder usar el mismo script que hemos usado para el fondo.

Se establecerá un sistema de reciclado de barreras. Aquellas que superen un cierto punto en su movimiento hacia la izquierda, serán desactivas y colocadas en un pool a la espera de poder ser usadas de nuevo. Cuando se deba colocar una nueva barrera se comenzará por comprobar si hay alguna disponible en el pool de desactivadas y de ser así se usará una de ellas. En caso de no haber disponibles se espaneará una nueva.

## Animación del personaje

El personaje del granjero lleva incorporado un animador que utilizaremos para darle vida. Este animador está controlado por numerosos parámetros, de los que a nosotros nos interesan solo algunos.

Para empezar, y dado que el personaje siempre se moverá a velocidad constante, podemos establecer directamente en el animador un valor lo suficientemente alto del parámetro speed_f para que ejecute la animación de correr.

Usaremos también jump_trig, y jump_b. El primero es un trigger y nos permitirá iniciar los saltos. El segundo es un booleano, asociado también a los saltos, y lo utilizaremos para hacer una transición desde el salto a una animación de caida y luego vuelta de nuevo a la animación de correr.

También utilizaremos el parámetro death_type para seleccionar el tipo de animación de muerte que ejecutará el personaje.
