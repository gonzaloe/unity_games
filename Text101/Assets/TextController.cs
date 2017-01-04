using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	public enum States {sheets_0, sheets_1, lock_0, lock_1, mirror, cell_mirror, courtyard, cell, corridor_0, 
						stairs_0, floor, closet_door, stairs_1, corridor_1, in_closet, corridor_2, corridor_3,
						stairs_2};
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == States.cell) {cell();} 
		else if (myState == States.sheets_0) {sheets_0();} 
		else if (myState == States.sheets_1) {sheets_1();} 
		else if (myState == States.lock_0) {lock_0();}
		else if (myState == States.lock_1) {lock_1();}
		else if (myState == States.mirror) {mirror();}
		else if (myState == States.cell_mirror) {cell_mirror();}
		else if (myState == States.corridor_0) {corridor_0();}
		else if (myState == States.stairs_0) {stairs_0();}
		else if (myState == States.floor) {floor();}
		else if (myState == States.closet_door) {closet_door();}
		else if (myState == States.stairs_1) {stairs_1();}
		else if (myState == States.corridor_1) {corridor_1();}
		else if (myState == States.in_closet) {in_closet();}
		else if (myState == States.corridor_2) {corridor_2();}
		else if (myState == States.corridor_3) {corridor_3();}
		else if (myState == States.stairs_2) {stairs_2();}
		else if (myState == States.courtyard) {courtyard();}
	}

	#region States handlers
	void cell () {
		text.text = "Te encuentras en una celda de prisión, y quieres escapar. Hay unas sábanas sucias sobre la cama, " +
					"un espejo en la pared, y la puerta está bloqueada desde afuera.\n\nPresiona S para examinar las " +
					"Sábanas, E para examinar el Espejo y C para examinar el Cerrojo.";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		} else if (Input.GetKeyDown(KeyCode.E)) {
			myState = States.mirror;
		} else if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.lock_0;
		}
	}
	
	void sheets_0 () {
		text.text = "No puedes creer que hayas dormido en esos trapos. Seguramente ya es hora de que alguien los cambie. " +
					"Los placeres de la vida en prisión supongo!\n\nPresiona R para Regresar a tu celda.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void sheets_1 () {
		text.text = "Sostener un espejo en tu mano no hace que las sábanas se vean para nada mejor.\n\nPresiona R para " +
					"Regresar a tu celda.";	
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}
	
	void lock_0 () {
		text.text = "Este es uno de esos candados de botones. No tienes idea de cuál es la combinación. Desearías de " +
					"alguna manera saber dónde estuvieron las sucias huellas dactilares, quizás eso ayudaría.\n\n" +
					"Presiona R para Regresar a tu celda.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void lock_1 () {
		text.text = "Cuidadosamente colocas el espejo a través de las barras, y lo giras de manera que puedes ver la cerradura. Puedes " +
					"ver las huellas dactilares alrededor de los botones. Presionas esos sucios botones, y escuchas un click.\n\n" +
					"Presiona A para Abrir, o R para Regresar a tu celda.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		} else if (Input.GetKeyDown(KeyCode.A)) {
			myState = States.corridor_0;
		}
	}
	
	void mirror () {
		text.text = "El sucio y viejo espejo en la pared parece estar suelto.\n\nPresiona L para levantarlo, o R para Regresar a la celda.";
		if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.cell_mirror;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void cell_mirror () {
		text.text = "Estás aún en tu celda, y AÚN quieres escapar! Hay algunas sábanas sucias sobre la cama, una marca en donde " +
					"se encontraba el espejo, y esa maldita puerta todavía ahí, firmemente bloqueada!\n\nPresiona S para examinar las " +
					"Sábanas, o C para examinar el Cerrojo.";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_1;
		} else if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.lock_1;
		}
	}
	
	void corridor_0() {
		text.text = "Estás fuera de tu celda, pero no fuera de problemas aún. Te encuentras en el pasillo, hay un armario " +
					"y algunas escaleras que llevan al patio. También hay varios restos en el piso.\n\nA para ver el Armario, " +
					"P para inspeccionar el Piso, y E para subir por las Escaleras.";
		if (Input.GetKeyDown(KeyCode.P)) {
			myState = States.floor;
		} else if (Input.GetKeyDown(KeyCode.E)) {
			myState = States.stairs_0;
		} else if (Input.GetKeyDown(KeyCode.A)) {
			myState = States.closet_door;
		}
	}

	void stairs_0() {
		text.text = "Empiezas a subir las escaleras siguiendo la luz que proviene del exterior. Te das cuenta que no es " +
					"tiempo de escapar, y que te van a capturar inmediatamente. Te deslizas de vuelta por las escaleras " +
					"a reconsiderarlo.\n\nPresiona R para Regresar al pasillo.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0;
		}
	}

	void stairs_1() {
		text.text = "Desafortunadamente, cargar un triste gancho de pelo no te da la confianza suficiente para caminar hacia " +
					"el patio rodeado de guardias!\n\n Presiona R para Retirarte por las escaleras.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_1;
		}
	}

	void stairs_2() {
		text.text = "Te sientes presumido por poder abrir la puerta del armario, y todavía armado con un gancho de pelo (ahora " +
					"doblado). Incluso estos logros acumulados no te dan el coraje necesario para subir las escaleras hacia tu " +
					"muerte!\n\nPresiona R para Regresar al pasillo.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_2;
		}
	}

	void courtyard() {
		text.text = "Caminas a través del patio vestido como un portero. El guardia mueve su sombrero a ti en señal de saludo a medida " +
					"que pasas caminando, reclamando tu libertad. Tu corazón se acelera a medida que te acercas al atardecer.\n\n" +
					"Presiona J para jugar nuevamente.";
		if (Input.GetKeyDown(KeyCode.J)) {
			myState = States.cell;
		}
	}

	void floor() {
		text.text = "Hurgando alrededor del piso sucio, encuentras un gancho de pelo.\n\nPresiona L para volver a Levantarte, " +
					"o G para tomar el Gancho de pelo.";
		if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.corridor_0;
		} else if (Input.GetKeyDown(KeyCode.G)) {
			myState = States.corridor_1;
		}
	}

	void corridor_1() {
		text.text = "Todavía en el pasillo. El piso sigue sucio. El gancho de pelo en la mano. Ahora qué? Te preguntas si " +
					"ese cerrojo en el armario puede sucumbir a forzarlo?\n\nF para forzar la cerradura, y E para subir las Escaleras.";
		if (Input.GetKeyDown(KeyCode.F)) {
			myState = States.in_closet;
		} else if (Input.GetKeyDown(KeyCode.E)) {
			myState = States.stairs_1;
		}
	}

	void corridor_2() {
		text.text = "De vuelta en el pasillo, rechazando vestirte como portero.\n\nPresiona A para volver al Armario, y E " +
					"para subir las Escaleras.";
		if (Input.GetKeyDown(KeyCode.A)) {
			myState = States.in_closet;
		} else if (Input.GetKeyDown(KeyCode.E)) {
			myState = States.stairs_2;
		}
	}

	void corridor_3() {
		text.text = "Te encuentras parado en el pasillo, ahora convencido de vestir como portero. Consideras fuertemente correr " +
					"hacia tu libertad.\n\nPresiona E para subir las Escaleras, o D para Desvestirte.";
		if (Input.GetKeyDown(KeyCode.E)) {
			myState = States.courtyard;
		} else if (Input.GetKeyDown(KeyCode.D)) {
			myState = States.in_closet;
		}
	}

	void closet_door() {
		text.text = "Estás viendo una puerta de armario, desafortunadamente bloqueada. Quizás podrías encontrar algo " +
					"alderedor que te ayude a abrirla?\n\nPresiona R para Regresar al pasillo.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0;
		} 
	}

	void in_closet() {
		text.text = "Dentro del armario encuentras un uniforme de portero que parece ser de tu talle! Parece que tu día " +
					"está mejorando.\n\nPresiona V para Vestirte, o R para Regresar al pasillo.";
		if (Input.GetKeyDown(KeyCode.V)) {
			myState = States.corridor_3;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_2;
		}
	}

	#endregion
}
