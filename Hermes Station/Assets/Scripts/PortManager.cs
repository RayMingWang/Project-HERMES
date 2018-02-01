using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortManager : MonoBehaviour {
	public Port[] portlist;
	public DialougeUnit left;
	public DialougeUnit right;
	public int stage=1;
	private int[] client_01= new int[] {-1,-1};
	private int[] client_02= new int[]{-1,-1};
	private ArrayList dialoguelist = new ArrayList();
	//private bool indialouge=false;
	private Animator left_anim;
	private Animator right_anim;
	private bool showDialogue = false;
	private int showPort =-2;

//	int index_01 = 0;
//	int index_02 = 0;
//	int index_order = 0;
	DialogueSet currentDialougueset;
	// Use this for initialization
	void Start () {
		DialogueSet newdialogue = new DialogueSet ();




		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is goint to talk
		newdialogue.setParticipants(1, 2);
		//The name
		newdialogue.name_01 = "Loop";
		newdialogue.name_02 = "Nova";
		//add line, order must be mantianed
		newdialogue.addLine01("What's the word my man?");
		newdialogue.addLine02("Nothin', you still fucking with Pinch?");
		newdialogue.addLine01("Nah, the stock dropped in Pinch by 75% You didn't see?");
		newdialogue.addLine02("Didn't I see? That's I didn't buy that shit in the first place");
		newdialogue.addLine02("You're just burning your creds and your time, ya waste of space");
		newdialogue.addLine01("Who's calling me a waste of space? At least I didn't ship ten tons of wheat to Ur-95.");
		newdialogue.addLine02("Ur-95?? HAHAHAHAHA! I wouldn’t waste my time, I went to Audamon-72. Tripled my earnings. What’re you doing here anyway? Going to try to beg Bell to come back to you?");
		newdialogue.addLine01("Me? Beg? Nah, it's the other way around. She's begging me.");
		newdialogue.addLine02("That's a load of bull and we both know it. Oh, I got a call with someone important. Smella ya later!");
		newdialogue.addLine01("Hey I wasn't...hello?");
		//order of participants
		newdialogue.order = new int[] { 1, 2, 1, 2, 2, 1, 2, 1, 2, 1 }; //Ends at Stage 10
		//when do you want the dialouge be avilable
		newdialogue.stage = 34;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);


		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is goint to talk
		newdialogue.setParticipants(1, 7);
		//The name
		newdialogue.name_01 = "Jam";
		newdialogue.name_02 = "Tongs";
		//add line, order must be mantianed
		newdialogue.addLine01("Hey Tons, I got the goods if you got the stuff.");
		newdialogue.addLine02("Oh I got the stuff.");
		//order of participants
		newdialogue.order = new int[] { 1, 2 };
		//when do you want the dialouge be avilable
		newdialogue.stage = 50;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);



		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is goint to talk
		newdialogue.setParticipants(0, 2);
		//The name
		newdialogue.name_01 = "Loop";
		newdialogue.name_02 = "Nova";
		//add line, order must be mantianed
		newdialogue.addLine02("Dummy says what?");
		newdialogue.addLine01("What?");
		newdialogue.addLine02("HAHAHAHA GOTCHA!");
		newdialogue.addLine01("Come on are youa  fucking child? I call cause I needed to ask you a question.");
		newdialogue.addLine01("It's serious.");
		newdialogue.addLine02("What? Can't remember what shoe goes on what foot?");
		newdialogue.addLine01("No?");
		newdialogue.addLine01("I don't have feet");
		newdialogue.addLine02("Well, you're missing out that's for sure. What's your question?");
		newdialogue.addLine01("Have you heard of this chick Hazel? About six feet tall, hands the size of your palm.");
		newdialogue.addLine02("Yeah heard she’s calling around getting the best of the best smugglers to form some type of pirate coalition. Why? Still waiting for your call?");
		newdialogue.addLine01("No, it's the opposite. She won't stop calling. Every damn day. I'm worried they're gonna come after me if I say no.");
		newdialogue.addLine02("Little baby Loop afraid of some competition?");
		newdialogue.addLine01("What ever dude, she probably hasn’t even called you, probably because you’re millions of creds in debt.");
		newdialogue.addLine02("Me? In debt? The only that I owe is your respect.");
		newdialogue.addLine02("HAHAHAHA");
		newdialogue.addLine01("Smell ya later!");
		newdialogue.addLine01("NOVA!");
		newdialogue.addLine01("*sigh*");

		//order of participants
		newdialogue.order = new int[] { 2, 1, 2, 1, 1, 2, 1, 1, 2, 1, 2, 1, 2, 1, 2, 2, 1, 1, 1 };
		//when do you want the dialouge be avilable
		newdialogue.stage = 85;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);


		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is goint to talk
		newdialogue.setParticipants(0, 2);
		//The name
		newdialogue.name_01 = "Loop";
		newdialogue.name_02 = "Nova";
		//add line, order must be mantianed
		newdialogue.addLine02("I was wondering something about you Loop...");
		newdialogue.addLine01("Oh you got a new joke today?");
		newdialogue.addLine02("No no no seriously I have a question. Really.");
		newdialogue.addLine01("Go on...");
		newdialogue.addLine02("What's it like having a butt so smelly you have to live inside of your spaceship?");
		newdialogue.addLine01("...");
		newdialogue.addLine02("HAHAHAHA! BUTT! SMELLY! HAHAHAHA");
		newdialogue.addLine01("Nova I have a cargo full of explosives. I'll end this now if I have to");
		newdialogue.addLine02("Oh Loop you don’t mean it! You wouldn’t dare. ");
		newdialogue.addLine01("Try me");
		newdialogue.addLine02("Hey come on you know I'm just messing with you");
		newdialogue.addLine01("The only thing you're messing with is a chance to get the teeth knocked out of you.");
		newdialogue.addLine02("I don't have teeth");
		newdialogue.addLine01("Fair point.");
		newdialogue.addLine02("Teeth are weird");
		newdialogue.addLine01("Super weird.");
		//order of participants
		newdialogue.order = new int[] { 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 }; //16
		//when do you want the dialouge be avilable
		newdialogue.stage = 139;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);

		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is goint to talk
		newdialogue.setParticipants(4, 2);
		//The name
		newdialogue.name_01 = "Nova";
		newdialogue.name_02 = "Hazel";
		//add line, order must be mantianed

		newdialogue.addLine02("Nova");
		newdialogue.addLine01("Huh? Who is this? Loop is that you?");
		newdialogue.addLine02("You know this isn’t sweet Loop. It’s Hazel.");
		newdialogue.addLine01("Yeah? What do you want?");
		newdialogue.addLine02("You. To join the Coalition I’m creating. ");
		newdialogue.addLine01("I'm listening...");
		newdialogue.addLine02("But there’s a test. Everyone who’s joined has had to pass the test");
		newdialogue.addLine01("Uh huh...");
		newdialogue.addLine02("You have to kill someone, destroy their ship and take their goods. It’s always someone who’s failed me. ");
		newdialogue.addLine01("Who's the target?");
		newdialogue.addLine02(" Loop. I’ve been trying to weeks to get him to join our cause and he’s been...difficult.");
		newdialogue.addLine01("You want me to kill Loop? You’re a fucking psycho. That’s my brother.");
		newdialogue.addLine02("I can remove the two of you if necessary.");
		newdialogue.addLine01("Don’t call me or Loop again. I’ll remove you if necessary.");
		//order of participants
		newdialogue.order = new int[] { 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };
		//when do you want the dialouge be avilable
		newdialogue.stage = 149;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);

		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is goint to talk
		newdialogue.setParticipants(1, 4);
		//The name
		newdialogue.name_01 = "Timely";
		newdialogue.name_02 = "Rose";
		//add line, order must be mantianed
		newdialogue.addLine01("Hi hey hello, how's it going?");
		newdialogue.addLine02("I'm sorry who are you?");
		newdialogue.addLine01("Just a person looking to have a good time momma");
		newdialogue.addLine02("Don't. I'll report you to the Bureau of Sexual Harassment");
		newdialogue.addLine01("Come on just trying to have a little fun.");
		newdialogue.addLine01("Hello?");
		//order of participants
		newdialogue.order = new int[] { 1, 2, 1, 2, 1, 1 };
		//when do you want the dialouge be avilable
		newdialogue.stage = 50;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);


		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is goint to talk
		newdialogue.setParticipants(0, 4);
		//The name
		newdialogue.name_01 = "Prawn";
		newdialogue.name_02 = "Blair";
		//add line, order must be mantianed
		newdialogue.addLine01("Hey Blair");
		newdialogue.addLine02("Hey it's Blair...");
		newdialogue.addLine01("Yeah...I know");
		newdialogue.addLine02("I'm away from my comms right now");
		newdialogue.addLine01("Kidding me?");
		newdialogue.addLine02("Leave a quick message and I'll back to you as soon as possible");

		//order of participants
		newdialogue.order = new int[] { 1, 2, 1, 2, 1, 2 };
		//when do you want the dialouge be avilable
		newdialogue.stage = 36;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);


		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is goint to talk
		newdialogue.setParticipants(3, 2);
		//The name
		newdialogue.name_01 = "Prawn";
		newdialogue.name_02 = "Blair";
		//add line, order must be mantianed
		newdialogue.addLine01("Hey why haven't you been returning my calls?");
		newdialogue.addLine02("Hey it's Blair, I'm away from my comms right now...");
		newdialogue.addLine01("Fuck...");
		//order of participants
		newdialogue.order = new int[] { 1, 2, 1 };
		//when do you want the dialouge be avilable
		newdialogue.stage = 55;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);



		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is goint to talk
		newdialogue.setParticipants(5, 3);
		//The name
		newdialogue.name_01 = "Detective";
		newdialogue.name_02 = "Timely";
		//add line, order must be mantianed
		newdialogue.addLine01("Hello my name is Detective Diez, mind if I ask you a few question?");
		newdialogue.addLine02("Sure, what can I do for you officer? Diez is a nice name.");
		newdialogue.addLine01("Sir, have you been contacting random docks and harassing pilots?");
		newdialogue.addLine02("What? We're all just having a little fun Officer. Nobody's getting hurt.");
		newdialogue.addLine01("So you admit to it?");
		newdialogue.addLine02("Yeah, but I didn't mean to hurt nobody. ");
		newdialogue.addLine01("Your admittance of guilt is noted. Your comms will be suspended for the next four weeks. ");
		newdialogue.addLine01("If you continue to exhibit this type of behavior you can, and will be expelled from the Galatic Communication system");
		newdialogue.addLine02("Oh come on I didn't...");
		newdialogue.addLine01("Your communications  will be suspended in 3...");
		newdialogue.addLine02("DETECTIVE!!!!!!!");
		newdialogue.addLine01("2...");
		newdialogue.addLine02("YOU PEICE OF SHIT DON'T YOU DARE");
		newdialogue.addLine01("1...Your communications are now suspended. Good day Mr. Timely.");

		//order of participants
		newdialogue.order = new int[] { 1, 2, 1, 2, 1, 2, 1, 1, 2, 1, 2, 1, 2, 1 };
		//when do you want the dialouge be avilable
		newdialogue.stage = 100;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);

		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is goint to talk
		newdialogue.setParticipants(8, 0);
		//The name
		newdialogue.name_01 = "Socket";
		newdialogue.name_02 = "Molli";
		//add line, order must be mantianed
		newdialogue.addLine01("Hello?");
		newdialogue.addLine02("Socket, it's me. Molli");
		newdialogue.addLine01("Hi!");
		newdialogue.addLine01("You don't know you don't have to come here all the time. I know you stopped trading ages ago.");
		newdialogue.addLine02("I do still need to travel, for a different purpose.");
		newdialogue.addLine01("You don't need to talk to atrade offical though.");
		newdialogue.addLine02("Would you prefer I not stop by?");
		newdialogue.addLine01("Of course not");
		newdialogue.addLine01("How's the family?");
		newdialogue.addLine02("My brother is still out on Iota 10. Last I heard, they're still scraping by.");
		newdialogue.addLine01("He's lucky, then. It's rough out there in the colonies.");
		newdialogue.addLine01("I don't suppose you...");
		newdialogue.addLine02("No, I haven't pushed the bill yet.");
		newdialogue.addLine01("No, I haven't pushed the bill yet.");
		newdialogue.addLine02("There just isn't enough support for it yet, Socket. I'm working on it but you know I'm still a nobody in the senate.");
		newdialogue.addLine01("Your brother, Molli. ");
		newdialogue.addLine02("I said I'm working on it.");
		newdialogue.addLine01("...");
		newdialogue.addLine02("Socket, come on. I wouldn't lie to you. These things just take time.");
		newdialogue.addLine01("Time Outworlders don't have!");
		newdialogue.addLine01("Or haven't you been listening to news anymore?");
		newdialogue.addLine02("Of course I've been listening. No one listens to me. ");
		newdialogue.addLine01("I can't just wave my hands and make things happen. That isn't how politics work.");
		newdialogue.addLine01("If you just show them the effects...tell them about your brother, make it personal...");
		newdialogue.addLine02("And when should I do that?!");
		newdialogue.addLine02("I'm lucky if the galatic senators so much as look in my direction");
		newdialogue.addLine01("You just need to...");
		newdialogue.addLine02("I have to go.");
		newdialogue.addLine01("Molli!");
		newdialogue.addLine01("Molli, I'm not done talking to you.");
		newdialogue.addLine01("Come on, I know you're still there.");
		newdialogue.addLine01("Answer me.");
		newdialogue.addLine01("Molli?");


		//order of participants
		newdialogue.order = new int[] { 1, 2, 1, 1, 2, 1, 2, 1, 1, 2, 1, 1, 2, 1, 2, 1, 2, 1, 2, 1, 1, 2, 1, 1, 2, 2, 1, 2, 1, 1, 1, 1, 1 };
		//when do you want the dialouge be avilable
		newdialogue.stage = 1;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);

		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is goint to talk
		newdialogue.setParticipants(8, 3);
		//The name
		newdialogue.name_01 = "Socket";
		newdialogue.name_02 = "Molli";
		//add line, order must be mantianed

		newdialogue.addLine02("Hello?");
		newdialogue.addLine01("Molli, I'm sorry. ");
		newdialogue.addLine02("...Oh.");
		newdialogue.addLine01("I'm  just frustrated, you know?");
		newdialogue.addLine02("Yes, I know I am too.");
		newdialogue.addLine02("You don't really think I'm not trying my hardest to get my brother help, do you?");
		newdialogue.addLine01("I guess not. Not really.");
		newdialogue.addLine01("It just feels like nothing's happening.");
		newdialogue.addLine02("Not quickly, no, but it will. You have my word");
		newdialogue.addLine01("*sights");
		newdialogue.addLine01("I actually have to go. I'm supposed to be in a meeting right now.");
		newdialogue.addLine01("I just that you docked and...");
		newdialogue.addLine02("That's okay.  I'll be back soon enough");
		newdialogue.addLine01("I know you will.");

		//order of participants
		newdialogue.order = new int[] { 2, 1, 2, 1, 2, 2, 1, 1, 2, 1, 1, 1, 2, 1 };
		//when do you want the dialouge be avilable
		newdialogue.stage = 45;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);

		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is goint to talk
		newdialogue.setParticipants(3, 4);
		//The name
		newdialogue.name_01 = "Voxel";
		newdialogue.name_02 = "Molli";
		//add line, order must be mantianed
		newdialogue.addLine02("Hello? Who's this?");
		newdialogue.addLine01("My name is Voxel, I sent you a di-em about trade route legislation a few days ago.");
		newdialogue.addLine02("Oh, the lobbyist");
		newdialogue.addLine01("I prefer Actvisit");
		newdialogue.addLine02("Of course you do.");
		newdialogue.addLine02("I'm not interested in whatever you're selling. I have work to do");
		newdialogue.addLine01("You'll be interested in this. I have the ear of several crucial members of the galatic senate.");
		newdialogue.addLine01(" If you want to speak to them, I would be happy to introduce you,");
		newdialogue.addLine02("If you have their ears, why are you talking to me?");
		newdialogue.addLine01("Because we don't have enough support.");
		newdialogue.addLine01("We need you to talk to the other members of your system senate, to spread our cause.");
		newdialogue.addLine01("Even the galactic senate can't ignore something a system senate passes.");
		newdialogue.addLine02("And if I do this, you'll get me connections in the galatic senate?");
		newdialogue.addLine01("Exactly.");
		newdialogue.addLine01("I'l leave you to consider the matter.");

		//order of participants
		newdialogue.order = new int[] { 2, 1, 2, 1, 2, 2, 1, 1, 2, 1, 1, 1, 2, 1, 1 };
		//when do you want the dialouge be avilable
		newdialogue.stage = 60;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);

		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is goint to talk
		newdialogue.setParticipants(8, 1);
		//The name
		newdialogue.name_01 = "Socket";
		newdialogue.name_02 = "Molli";
		//add line, order must be mantianed
		newdialogue.addLine02("Socket?");
		newdialogue.addLine01("Molli! Hi!");
		newdialogue.addLine02("When is your next shore leave?");
		newdialogue.addLine01("Two days, but it's only for the weekend. Why?");
		newdialogue.addLine02("Come to Luxit?");
		newdialogue.addLine02("There's a place I want to show you.");
		newdialogue.addLine01("Oh? What kind of place?");
		newdialogue.addLine02("I could leave it a surprise...");
		newdialogue.addLine01("No, come on, I need to know something.");
		newdialogue.addLine01("You wouldn't want me to be overdressed would you?");
		newdialogue.addLine01("I don't think I'd mind.");
		newdialogue.addLine02("But if it will satisfy your curiousity, it's a resaurant.");
		newdialogue.addLine02("It's known for its Forrean cuisine.");
		newdialogue.addLine01("Oh!");
		newdialogue.addLine01("That's my favorite!");
		newdialogue.addLine02("I know.");
		newdialogue.addLine01("I'll be there!");
		newdialogue.addLine02("See you then, socket");
		//order of participants
		newdialogue.order = new int[] { 2, 1, 2, 1, 2, 2, 1, 2, 1, 2, 1, 1, 1, 2, 2, 1, 1, 2, 1, 2 };
		//when do you want the dialouge be avilable
		newdialogue.stage = 77;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);




		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is going to talk
		newdialogue.setParticipants(1, 4);
		//The name
		newdialogue.name_01 = "Voxel";
		newdialogue.name_02 = "Molli";
		//add line, order must be maintained
		newdialogue.addLine02("Hello?");
		newdialogue.addLine01("Hello, Molli. Have you considered my proposal?");
		newdialogue.addLine02("I've considered it.");
		newdialogue.addLine01("And?");
		newdialogue.addLine02("And I want proof you can keep your word.");
		newdialogue.addLine02("You could be lying through your teeth for all I know.");
		newdialogue.addLine01("I don't have teeth.");
		newdialogue.addLine01("But I do have proof.");
		newdialogue.addLine01("I can arrange a meeting with Senator <name> when he visits Napoleon in a couple of days.");
		newdialogue.addLine01("Will you be there?");
		newdialogue.addLine02("...We'll see.");
		newdialogue.addLine01("I'll see you there, then.");
		//order of participants
		newdialogue.order = new int[] { 2, 1, 2, 1, 2, 2, 1, 1, 1, 1, 2, 1 };
		//when do you want the dialogue be available
		newdialogue.stage = 87;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);

		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is going to talk
		newdialogue.setParticipants(24, 114);
		//The name
		newdialogue.name_01 = "Socket";
		newdialogue.name_02 = "Molli";
		//add line, order must be maintained
		newdialogue.addLine02("Socket?");
		newdialogue.addLine01("Yes.");
		newdialogue.addLine01("Who were you talking to? I called just after you docked but your line was busy. ");
		newdialogue.addLine02("A representative from the <name> Trade Group. ");
		newdialogue.addLine01("Ugh. The ones who think the outworlders are a waste of resources?");
		newdialogue.addLine02("That isn't part of their official platform, but... it's not an uncommon belief, yes. ");
		newdialogue.addLine01("What did they want with you?");
		newdialogue.addLine02("The usual. An ear in the senate, someone to do their lobbying for them. ");
		newdialogue.addLine02("I doubt they will get anywhere, but I might still be able to use their connections. ");
		newdialogue.addLine01("That seems...dangerous");
		newdialogue.addLine02("It's politics. ");
		newdialogue.addLine01("[sighs]");
		newdialogue.addLine01("Let's talk about something less annoying. ");
		newdialogue.addLine02("[chuckles]");
		newdialogue.addLine01("Thanks for dinner the other night!");
		newdialogue.addLine01("I still need to repay you for that. ");
		newdialogue.addLine02("Don't worry about it, it was my pleasure. ");
		newdialogue.addLine01("I still want to treat you sometime. ");
		newdialogue.addLine01("You'll be in New New Jersey City next week, right?");
		newdialogue.addLine02("On Tau-42? Yes. ");
		newdialogue.addLine01(" I know a great place in the undertown. It looks a little seedy but the food is fantastic. ");
		newdialogue.addLine02("Is this the sort of place in which a politician such as myself should avoid being seen?");
		newdialogue.addLine01("No!");
		newdialogue.addLine01("Well, keep a low profile. But it's Tau-42, no one cares. ");
		newdialogue.addLine02("All right, I trust you. ");
		newdialogue.addLine01("Great! I'll meet you at the Great Plateau.");
		newdialogue.addLine02("Perfect. ");
		//order of participants
		newdialogue.order = new int[] { 2, 1, 1, 2, 1, 2, 1, 2, 2, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 2, 1, 1, 2, 1, 2 };
		//when do you want the dialogue be available
		newdialogue.stage = 114;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);

		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is going to talk
		newdialogue.setParticipants(8, 4);
		//The name
		newdialogue.name_01 = "Socket";
		newdialogue.name_02 = "Molli";
		//add line, order must be maintained
		newdialogue.addLine02("Hello.");
		newdialogue.addLine01("Hi Molli!");
		newdialogue.addLine02("Socket. ");
		newdialogue.addLine02("Oh, someone else is trying to call me. ");
		newdialogue.addLine01("I can call back later.");
		newdialogue.addLine02("It's likely only the trade rep again. ");
		newdialogue.addLine01("Ughhh tell them to go away. We don't want their stupid monopoly here. ");
		newdialogue.addLine02("They're still useful to me. ");
		newdialogue.addLine01("[grumbles]");
		newdialogue.addLine01("What do you even get out of this?");
		newdialogue.addLine02("Connections. ");
		newdialogue.addLine02("They have introduced me to one of the galactic senators already. ");
		newdialogue.addLine01("And if you make a good impression on that senator they'll support you when you run for galactic senate. ");
		newdialogue.addLine02("Exactly. ");
		newdialogue.addLine02("See, you're getting it now. ");
		newdialogue.addLine01("Doesn't mean I like it. ");
		newdialogue.addLine01("[sighs]");
		newdialogue.addLine01("But yes, I get it. So you're helping them so you can make connections, but not so much that they actually get anywhere. ");
		newdialogue.addLine02("That's the aim. ");
		newdialogue.addLine01("All right. I'll let you go, then, I'm sure they're still calling. ");
		newdialogue.addLine01("Good luck!");
		newdialogue.addLine02("Thank you. ");
		//order of participants
		newdialogue.order = new int[] { 2, 1, 2, 2, 1, 2, 1, 2, 1, 1, 2, 2, 1, 2, 2, 1, 1, 1, 2, 1, 1, 2 };
		//when do you want the dialogue be available
		newdialogue.stage = 164;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);

		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is going to talk
		newdialogue.setParticipants(1, 2);
		//The name
		newdialogue.name_01 = "Voxel";
		newdialogue.name_02 = "Molli";
		//add line, order must be maintained
		newdialogue.addLine02("Voxel, I assume?");
		newdialogue.addLine01("Correct. ");
		newdialogue.addLine01("Have you made progress?");
		newdialogue.addLine02("I've talked Jan into supporting your bill, and I believe <name> may follow suit shortly. ");
		newdialogue.addLine01("Excellent. You should receive a di-em from <name> shortly. ");
		newdialogue.addLine02("Thank you. ");
		newdialogue.addLine02("If I may offer some advice?");
		newdialogue.addLine01("By all means. ");
		newdialogue.addLine02("Though some traders naturally oppose your bill, many others are frustrated with the speed--or, rather, lack thereof--of government processes and may be open to your cause.");
		newdialogue.addLine02("Rallying them to contact the senators of their planets or systems could get you far.");
		newdialogue.addLine01("I see.");
		newdialogue.addLine01("Thank you; I will let my team know.");
		newdialogue.addLine01("And I will see who else I can convince to meet with you in return.");
		newdialogue.addLine02("I appreciate that.");
		//order of participants
		newdialogue.order = new int[] { 2, 1, 1, 2, 1, 2, 2, 1, 2, 2, 1, 1, 1, 2 };
		//when do you want the dialogue be available
		newdialogue.stage = 182;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);

		newdialogue = new DialogueSet();
		//which port is going to talk
		newdialogue.setParticipants(8, 3);
		//The name
		newdialogue.name_01 = "Molli";
		newdialogue.name_02 = "Socket";
		newdialogue.addLine02("Back already?");
		newdialogue.addLine01("And with two new connections, no less.");
		newdialogue.addLine02("Wow. I guess this deal thing is pretty effective.");
		newdialogue.addLine01("I'd advise you to try it some time, but I expect your only opportunities would be traders attempting to bribe you into letting their illegal shipments pass.");
		newdialogue.addLine02("Ha! Yes, that's true. They try that all the time.");
		newdialogue.addLine02("And then I kick them out.");
		newdialogue.addLine01("You're honest, Socket. I've always loved that about you.");
		newdialogue.addLine02("...");
		newdialogue.addLine01("Socket?");
		newdialogue.addLine02("Sorry, wasn't expecting that. Um. Thanks?");
		newdialogue.addLine01("[chuckles]");
		newdialogue.addLine02("I really admire your... persistence? I don't know, we've been friends so long and you used to be a newbie trader and now you're a senator.");
		newdialogue.addLine02("Is it weird if I say I'm proud of you?");
		newdialogue.addLine01("You used to be a dock technician and now you manage the entire station, Socket. I'm proud of you, too.");
		newdialogue.addLine02("We've really come far, haven't we?");
		newdialogue.addLine01("And we've a long ways yet to go.");
		newdialogue.addLine01("Together, I hope.");
		newdialogue.addLine02("Yes! Definitely together.");
		newdialogue.addLine02("I wouldn't want it any other way.");
		newdialogue.addLine01("...");
		newdialogue.addLine02("...");
		newdialogue.addLine01("[sighs] I think Voxel is calling me again.");
		newdialogue.addLine02("Go ahead, I should get back to work anyway. ");
		newdialogue.addLine01("I will talk to you again soon.");
		newdialogue.addLine02("I'll be waiting! ");
		newdialogue.addLine02("And, Molli?");
		newdialogue.addLine01("Yes?");
		newdialogue.addLine02("...I love you.");
		newdialogue.addLine01("I love you, too.");
		//order of participants
		newdialogue.order = new int[] { 2, 1, 2, 1, 2, 2, 1, 2, 1, 2, 1, 2, 2, 1, 2, 1, 1, 2, 2, 1, 2, 1, 2, 1, 2, 2, 1, 2, 1 };
		//when do you want the dialogue be available
		newdialogue.stage = 196;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);

		//must have leave it be
		newdialogue = new DialogueSet();
		//which port is going to talk
		newdialogue.setParticipants(4, 3);
		//The name
		newdialogue.name_01 = "Voxel";
		newdialogue.name_02 = "Molli";
		//add line, order must be maintained
		newdialogue.addLine01("Before I leave the station, I wanted to let you know that Torch will send you a di-em within the week.");
		newdialogue.addLine02("Thank you. I have a question for you, if you don't mind.");
		newdialogue.addLine01("Not at all.");
		newdialogue.addLine02("I understand many of your group are opposed to sending aid to outworlders. Given that you want control of some of the busiest trade routes in the galaxy, and that I have family in the outworlds...");
		newdialogue.addLine01("You're concerned. I understand.");
		newdialogue.addLine01("I can't promise some outworlds won't be affected, but I'm sure certain exceptions can be made.");
		newdialogue.addLine02("...");
		newdialogue.addLine02("Fine.");
		newdialogue.addLine02("I'll speak with you again later.");
		newdialogue.addLine01("Goodbye, Molli.");
		//order of participants
		newdialogue.order = new int[] { 1, 2, 1, 2, 1, 1, 2, 2, 2, 1 };
		//when do you want the dialogue be available
		newdialogue.stage = 227;
		//must have leave it be
		newdialogue.ResetConversation();
		dialoguelist.Add(newdialogue);


	}


    public void recieveConnection(int client,int portid){
		if (portid <= -1)
			return;
		Debug.Log ("connect"+ portid);
		portlist [portid].colid.enabled = false;
		if (client == -1) {
			CheckLine (-1, portid);
			showDialogue = true;
			showPort = portid;
		}
		if (client == 1) {
			if (client_01 [0] == -1)
				client_01 [0] = portid;
			else
				client_01 [1] = portid;
			if (client_01 [0] >= 0 && client_01 [1] >= 0) {
				CheckLine (client_01 [0],client_01 [1]);

			}	
		}
		if (client == 2) {
			if (client_02 [0] == -1)
				client_02 [0] = portid;
			else
				client_02 [1] = portid;
			if (client_02 [0] >= 0 && client_02 [1] >= 0) {
				CheckLine (client_02 [0],client_02 [1]);

			}	
		}
	}

	public void recieveDisconnection(int client,int portid){
		if (portid == -1) {
			Debug.Log ("-1bug");
			return;
		}
		Debug.Log ("disconnect"+portid);
		portlist [portid].colid.enabled = true;
		if (client == -1) {
			CheckActiveLine (-1, portid);
			showDialogue = false;
			showPort = -2;
			right_anim = right.GetComponent<Animator> ();
			right_anim.SetBool ("isOpen", false);
			left_anim = left.GetComponent<Animator> ();
			left_anim.SetBool ("isOpen", false);
		}
			
		if (client == 1) {
			CheckActiveLine (client_01 [0],client_01 [1]);
			if (client_01 [0] == portid)
				client_01 [0] = -1;
			else
				client_01 [1] = -1;
		}

		if (client == 2) {
			CheckActiveLine (client_02 [0],client_02 [1]);
			if (client_02 [0] == portid)
				client_02 [0] = -1;
			else
				client_02 [1] = -1;
		}
	}

	public void CheckActiveLine(int a, int b){
		DialogueSet target;
		for (int i = 0; i < dialoguelist.Count; i++) {
			target = (DialogueSet)dialoguelist [i];
			target.ResetConversation (a, b);
		}
	}

	public void CheckLine(int a, int b){
		DialogueSet target;
		for (int i = 0; i < dialoguelist.Count; i++) {
			target = (DialogueSet)dialoguelist [i];
			target.checkAvailability (a, b,stage);/*
			if(target.checkAvailability (a, b,stage);){
				showDialogue = true;
				showPort = a;
			}
		*/
		}
//		DialogueSet target;
//		for (int i = 0; i < dialoguelist.Count; i++)
//		{
//			target = (DialogueSet)dialoguelist[i];
//			target.checkAvailability (a, b, stage);
//				left.updateName(target.name_01);
//				right.updateName(target.name_02);
//				indialouge = true;
//				index_01 = 0;
//				index_02 = 0;
//				index_order = 0;
//				currentDialougueset = target;
//				left.updateDialouge ("");
//				right.updateDialouge ("");
//				left_anim=left.GetComponent<Animator>();
//				if (target.name_01.Equals ("no")) {
//					Debug.Log ("This is the one");
//
//				} else {
//					left_anim.SetBool ("isOpen", true);
//				}
//				right_anim =right.GetComponent<Animator>();
//				right_anim.SetBool ("isOpen", true);
//				return;
//			}
//		} 
	}

	void Update() {
		if (Input.GetKeyDown ("space")) {

			DialogueSet target;
			for (int i = 0; i < dialoguelist.Count; i++) {
				target = (DialogueSet)dialoguelist [i];
				if (target.forwardConversation (stage)) {
					portlist [target.participants_01].bulbOn();
					portlist [target.participants_02].bulbOn();
				}
				if (showDialogue) {
					if (target.state == 0)
						continue;
					if (target.isReachable (showPort)) {
						if (target.currentside == 1) {
							left_anim = left.GetComponent<Animator> ();
							left_anim.SetBool ("isOpen", true);
							left.updateName (target.currentName);
							left.updateDialouge (target.currentCoversation);


						} else if(target.currentside == 2){
							right_anim = right.GetComponent<Animator> ();
							right_anim.SetBool ("isOpen", true);
							right.updateName (target.currentName);
							right.updateDialouge (target.currentCoversation);
						}else if(target.state==2){
							right_anim = right.GetComponent<Animator> ();
							right_anim.SetBool ("isOpen", false);
							left_anim = left.GetComponent<Animator> ();
							left_anim.SetBool ("isOpen", false);
							target.state = 3;
							portlist [target.participants_01].bulbOff ();
							portlist[target.participants_02].bulbOff();
						}

					}
				}
			}

			stage++;
		}

	}
}
