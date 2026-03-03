# EventSystem
## Introducción
La intención didáctica de este ejercicio es entender un proyecto ajeno e implementar un sistema de eventos. Para esto se ha proporcionado [este respositorio](https://github.com/yeagob/Advanced2) para refactorizar.
En concreto se ha pedido modificar dos escenas: EventSystem e InventorySystem.
## EventSystem
En esta escena se encuentra un player con una barra de vida y un contador de puntos. El jugador puede alterar la vida del player dañándolo o curándolo, así como matándolo. También es posible ganar puntos.
### Reformas
- Implementar un sistema de inputs.
  - Resumen de la solución:
    InputSystem | EventSystem | Health / Points |
    :---: | :---: | :---: |
    OnKeyDamage | OnGetDamage() | GetDamage() |
    OnKeyHeal | OnGetHeal() | GetHeal() |
    OnKeyPoints | OnGetPoints() | AddPoints() |

- Añadir un sistema de niveles.
  - Resumen de la solución:  
    Añadir un nuevo componente TMPro para mostrar el nivel por pantalla. Cada 500 puntos conseguidos, el nivel se actualizará sumando 1.

### Funcionamiento
- Al pulsar la tecla ``Q`` se aplicarán 20 puntos de daño, actualizando la barra de vida y reproduciendo el correspondiente sonido de daño.
- Al pulsar la tecla ``E`` se recuperarán 20 puntos de vida, actualizando la barra de vida.
- Si se llega a los 0 puntos de vida el player morirá, desapareciendo de la escena y reproduciendo el correspondiente sonido de muerte.
- Al pulsar la tecla ``Space`` se ganarán 100 puntos. Cada 500 puntos se sumará 1 al nivel.

### UML
...

## InventorySystem
Esta escena representa un sistema de inventario. Todos los items disponibles se ubicarán en la parte superior (ItemPool) en forma de botones.
Los items dentro del inventario se alamacenarán en el panel de abajo a la izquierda (Inventory), y las posibles interacciones aparecerán a la derecha (ActionPanel), dependiendo del item seleccionado.
### Reformas
- Añadir UIController.
  - Resumen de la solución:  
    Mover todo lo relativo a la UI desde InventorySystem hasta una nueva clase UIController. (``UIReffs``, ``_currentItemSelected``, ``InitializeUI()``, ``AddItem()``, ``SelectItem()``)
    
- Añadir un sistema de eventos.
  - Resumen de la solución:
    |  | InventorySystem | EventSystem | UIController |
    :---: | :---: | :---: | :---: |
    | → | OnInitialize | OnInitializeUI() | InitializeUI() |
    | → | OnConsumeItem | OnDestroyButton() | DestroyButton() |
    | ← | SellCurrentItem() | OnSellItem() | OnSellItem |
    | ← | UseCurrentItem() | OnUseItem() | OnUseItem |

### Funcionamiento
- Al pulsar los posibles items de ItemPool, estos items aparecerán en el Inventory.
- Al pulsar los items de Inventory, en el ActionPanel se habilitarán los botones de Sell y Use, dependiendo de las características de item seleccionado.
- La función de los botones de ActionPanel dependen del item seleccionado. Por ejemplo si se usa un arma aparecerá por consola el menaje de ataque.
Pero si se usa una comida se indicarán los puntos de vida recuperados y el item desaparecerá de Inventory.

### UML
...



