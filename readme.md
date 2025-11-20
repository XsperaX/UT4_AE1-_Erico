# 🎮 Roll-a-Ball (Versión Mejorada)

**Autor:** Erico Pérez Cárdenes  
**Asignatura:** PGL  
**Versión de Unity:** 6.0  
**Proyecto:** UT4_AE1_Erico  

---

## 🧠 Descripción general
Este proyecto está basado en el clásico tutorial *Roll-a-Ball* de Unity Learn.  
A partir de ese punto, he añadido varias mejoras para hacerlo más completo y divertido.  
Entre los cambios que implementé están el sistema de puntuación, la posibilidad de saltar, un enemigo con IA, y la opción de reiniciar la partida al ganar o perder.

---

## 🕹️ Controles del juego

| Acción | Tecla |
|--------|-------|
| Moverse | WASD o Flechas |
| Saltar | Barra espaciadora |
| Reiniciar partida | R |

---

## 🎯 Objetivo del juego
El jugador controla una bola que debe recoger todos los objetos **PickUp** repartidos por el escenario.  
Cada vez que recoge uno, aumenta su **puntuación**.  
Al llegar a **12 puntos**, el jugador gana la partida.  
Si el enemigo alcanza al jugador, se pierde y aparece un mensaje en pantalla con la opción de reiniciar.

---

## ⚙️ Características principales
- **Movimiento físico** usando `Rigidbody` y fuerzas aplicadas en `FixedUpdate()`.  
- **Puntuación dinámica** mostrada en pantalla con `TextMeshPro`.  
- **Sistema de salto** controlado por la barra espaciadora, con detección de suelo mediante etiquetas (`Ground`).  
- **IA enemiga** implementada con `NavMeshAgent`, que persigue al jugador durante la partida.  
- **Reinicio de partida** mediante la tecla **R**, gestionado con un script `RestartManager`.  
- **Mensajes dinámicos** de victoria o derrota con textos en español.

---

## 🧩 Estructura del proyecto
- **Assets/Scripts/**
  - `PlayerController.cs`: controla el movimiento, puntuación y colisiones.  
  - `EnemyMovement.cs`: gestiona el comportamiento del enemigo con IA.  
  - `RestartManager.cs`: permite reiniciar la partida tras ganar o perder.  
  - `CameraController.cs`: sigue al jugador durante la partida.
- **Escenas:**
  - `Level1`: escenario principal con el jugador, los pickups y el enemigo.

---

## 💡 Aspectos destacables de Unity
- Uso de **TextMeshPro** para textos más nítidos y personalizables.  
- Implementación de **NavMesh** y **NavMeshAgent** para la IA.  
- Configuración de **tags** personalizadas (`Ground`, `Enemy`, `PickUp`) para mejorar la detección de colisiones.  
- Uso del **nuevo sistema de entrada (Input System)**.  
- Control de físicas y salto en `FixedUpdate()` para una jugabilidad fluida.

---

## 🏁 Cómo jugar
1. Puedes usar el Zip del código y extraerlo en un carpeta.
2. Seleccionar en el Unity Hub la carpeta extraida.
3. Una vez que haya cargado completamente Unity, tenemos que cargar la escena la cual es ....Erico-master\Assets\Scenes\nivel1
4. Empezar a jugar.
5. Si ganas o pierdes, pulsa **R** para volver a empezar.

---
# 🆕 Versión 2.0 – Entrega Final

En esta actualización final del proyecto he añadido y mejorado varios aspectos importantes para completar la práctica de forma más profesional y pulida.

## 🌟 Novedades principales

### ✔️ Menú principal funcional
- Botón para acceder al **Nivel 1**  
- Botón para acceder al **Nivel 2 (Nivel Extra para cumplir con lo de tener varias escenas.)**  
- Botón **Salir**  
- Texto personalizado  
- Imagen de fondo diseñada exclusivamente para el menú

### ✔️ Nivel extra (Nivel 2)
- Nuevo escenario totalmente jugable  
- Distribución diferente de pickups  
- Más enemigos y obstáculos  
- Textos de victoria y derrota funcionando  
- NavMesh configurado correctamente

### ✔️ Fondo personalizado en el menú
Añadida una imagen creada especialmente para el juego:  
**“Juego de Bolas – Práctica”**  
con la firma:  
**“Creado por Erico Pérez Cárdenes”**


## 📸 Capturas de pantalla
![Juego](images/1.jpg)
![Derrota](images/2.jpg)
![Pantalla de victoria](images/3.jpg)

# 📸 Capturas de pantalla Versión 2.0 – Entrega Final
![Menú](https://github.com/user-attachments/assets/f51a36da-2745-4ed6-a085-0806a81ad8a4)
![Nivel 1](https://github.com/user-attachments/assets/747218c3-1a76-42fc-bbf9-db6043eb4a53)
![nivel 2](https://github.com/user-attachments/assets/e0dab38c-0223-4328-b1cd-bea6b8fe9bc4)
![Victoria ir al menú](https://github.com/user-attachments/assets/11ac6ecc-4adb-4a7f-9e3d-8e3f22f06b72)
![Derrota](https://github.com/user-attachments/assets/c0873926-0d76-4161-8dbd-f99362da8156)
![puntuación](https://github.com/user-attachments/assets/7f9c9e55-3a8e-4319-8ee0-c4bcf4501384)





## 📚 Créditos
Proyecto desarrollado por **Erico Pérez Cárdenes** como parte de la asignatura **PGL**.  
Basado en el curso oficial **Roll-a-Ball** de Unity Learn, con modificaciones y ampliaciones propias.
