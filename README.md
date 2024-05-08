# game
Bienvenidos al emocionante mundo de estrategia, poder y magia encerrado en un juego de cartas multiplayer inspirado en el universo del famoso juego Gwent: The Witcher Card Game.
En este reino de batallas épicas, los jugadores se sumergirán en una guerra ancestral entre dos poderosas facciones: las misteriosas Fairies y los despiadados Demons. Cada facción despliega su arsenal de criaturas mágicas, hechizos devastadores y habilidades únicas en un campo de batalla estratégico donde cada movimiento cuenta.
Fairies: La Gracia de la Naturaleza
Los Fairies, protectores del bosque y las criaturas mágicas, despliegan su encanto natural para controlar el campo de batalla. Con una combinación de astucia, agilidad y poderes místicos, estas criaturas etéreas buscan mantener el equilibrio en el reino y defender su territorio de la invasión Demon.
Demons: El Poder de la Oscuridad
Los Demons, seres de pesadilla y poder infernal, se alzan desde las profundidades del inframundo para conquistar y destruir. Con fuerza bruta, hechizos corruptos y una sed insaciable de dominación, los Demons buscan someter a todas las criaturas bajo su yugo oscuro y despiadado.
Las partidas se disputan en una serie de rondas. Cada partida consta de un máximo de tres rondas. El jugador que gane dos de estas rondas será declarado ganador de la partida.
1.	Inicio de la Ronda:
Al inicio de cada partida, cada jugador recibe una mano inicial de 10 cartas. Tienen la posibilidad de intercambiar hasta dos de esas cartas haciendo clic derecho sobre ellas, lo que las devuelve a sus respectivos mazos. Este proceso permite a los jugadores ajustar su mano inicial antes de comenzar a jugar, ofreciendo flexibilidad estratégica desde el principio de la partida.
2.	Jugando Cartas:
Durante cada ronda, los jugadores se turnan para jugar cartas de su mano, desplegando criaturas, lanzando hechizos y activando habilidades especiales para ganar ventaja sobre su oponente. Utilizan cartas de su mano para construir un campo de batalla poderoso y resistente.
3.	Turnos de los Jugadores:
Un turno consiste en una de tres posibles acciones: jugar una carta, pasarse o activar el efecto del líder.
4.	Activación del Efecto del Líder:
Cada jugador tiene la oportunidad de activar el efecto de su líder una vez durante la partida. Este efecto especial puede proporcionar una ventaja estratégica crucial en el momento adecuado, pero debe ser usado con sabiduría, ya que solo se puede activar una vez en toda la partida.
5.	Objetivo de la Ronda:
El objetivo de cada ronda es acumular un total de puntos mayor que el oponente en el campo de batalla. Los puntos se ganan al desplegar cartas con valores numéricos y al aprovechar las sinergias entre las cartas de la misma facción.
6.	Fin de la Ronda:
Una vez que ambos jugadores han jugado todas las cartas que deseen o pueden, la ronda llega a su conclusión. El jugador con más puntos al final de la ronda gana esa ronda en particular.
7.	Preparación para la Siguiente Ronda:
Después de cada ronda, los jugadores tienen la oportunidad de ajustar sus estrategias para la siguiente ronda. Además, cada jugador roba dos cartas de su mazo, siempre y cuando el número total de cartas en su mano no exceda de 10.
8.	Ganar la Partida:
El primer jugador en ganar dos rondas es declarado ganador de la partida. Esto significa que, incluso si un jugador pierde la primera ronda, aún tiene la oportunidad de recuperarse y ganar las siguientes dos rondas para triunfar en el enfrentamiento.
Tipos de cartas:
Cartas de Unidad:
Cada carta posee un nombre y una imagen que la identifican, un texto de descripción donde se define el efecto que tiene (si tiene) y el tipo de carta q es (plata u oro) y puntos de ataque.
Además, cada carta de unidad posee un único tipo de ataque: [M] (Melee), [R] (Ranged) o [S] (Siege). Las cartas [M], [R] o [S] se juegan en una de las filas de combate disponibles. Cada unidad tiene un indicador de poder que representa su fuerza en el campo de batalla.
Además, al ser colocadas en juego, las unidades pueden desencadenar poderes especiales:
1.	Eliminar la carta con más poder del campo del rival.
2.	Eliminar la carta con menos poder del rival.
3.	Robar una carta.
4.	Multiplicar por n su ataque, siendo n la cantidad de cartas iguales a ella en el campo.
5.	Limpia la fila del campo no vacía del rival con menos unidades.
6.	Calcular el promedio de poder entre todas las cartas del campo propio. Luego igualar el poder de todas las cartas del campo (propias o del rival) a ese promedio.
Cartas Especiales:
Junto con las cartas de unidad, el juego cuenta con una variedad de cartas especiales:
1.	Clima: Afectan una o varias filas simultáneamente, penalizando en 2 puntos el ataque de las unidades en esas filas.
Entre las cartas clima disponibles se encuentran:
•	Lluvia torrencial
•	Escarcha Heladora
•	Niebla Impenetrable
2.	Aumentos: Otorgan bonificaciones (2 puntos) al ataque de las unidades en una fila específica. Cada deck presenta tres cartas de aumento. Una por fila.
3.	Despeje: Eliminan cartas de tipo clima, limpiando el campo de las penalizaciones impuestas.
4.	Señuelo: Permite colocar una carta con poder 0 en lugar de una carta del campo, devolviendo esta última a la mano. Esta carta especial ofrece una ventaja táctica significativa al permitir al jugador retirar una carta poderosa de su campo para poder usarla posteriormente.
Que la suerte y la estrategia guíen tu camino en "Realm of Fae & Demon". ¿Estás listo para embarcarte en esta odisea de cartas y encantamientos?
Detalles de la implementación del juego:
El juego fue creado en Unity. Entre los principales scripts del mismo se encuentran:
•	CardUnity : Contempla todas las propiedades que presentan las cartas de unidad
•	CartasEscpeciales: Contempla las propiedades de las cartas especiales
•	GameManager : Se controla toda la lógica del juego, el sistema de turnos, la cantidad de rondas jugadas, cuando se acaba la ronda, que jugador gano, etc.
•	Efectos: Este script contiene los efectos mencionados anteriormente de las cartas de tipo unidad, las cartas lideres, algunos métodos que se usan en el GameManager y el efecto de las cartas especiales (excepto el efecto de las cartas clima que se encuentra en un script aparte)
•	Los scripts MoverCarta y MoverCartaEspecial controlan el movimiento de las cartas de unidad y las cartas especiales respectivamente
•	Cada zona tiene además asociado un script (Zona CM; ZonaClima y ZonaAumento), en los cuales se utilizan métodos de Unity como es el caso de OnCollisionEnter2D y OnCollisionExit2D.
