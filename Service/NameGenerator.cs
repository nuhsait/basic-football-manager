using Vfm.Data;

namespace Vfm.Service;

public static class NameGenerator
{
    private record NamePool(string[] FirstNames, string[] LastNames);
    private static readonly Random Rng = new();
    private static readonly Dictionary<Country, NamePool> PlayerPools = new()
    {
        [Country.Turkey] = new(
            [
                "Ahmet", "Mehmet", "Mustafa", "Ali", "Veli", "Hasan", "Hüseyin", "İbrahim", "İsmail", "Osman",
                "Yusuf", "Ömer", "Emre", "Burak", "Murat", "Serkan", "Onur", "Kaan", "Arda", "Eren",
                "Kerem", "Mert", "Furkan", "Enes", "Berat", "Yunus", "Salih", "Hakan", "Tolga", "Volkan",
                "Barış", "Oğuz", "Umut", "Deniz", "Ege", "Berk", "Batuhan", "Alperen", "Yiğit", "Tuna",
                "Cengiz", "Okay", "Ozan", "Selçuk", "Caner", "Uğur", "Abdülkerim", "Halil", "Doğukan", "Semih",
                "Cenk", "Kenan", "Merih", "Ferdi", "Orkun", "İrfan", "Can", "Zeki", "Çağlar", "Abdülkadir",
                "Altay", "Uğurcan", "Ersin", "Mahmut", "Alper", "Oğuzhan", "Rıdvan", "Eray", "Sinan", "Gökhan",
                "Tarık", "Selim", "Serdar", "Nihat", "Hamit", "Tuncay", "Rüştü", "Bülent", "Tugay", "Alpay",
                "Ümit", "Fatih", "Gökdeniz", "Sabri", "Servet", "Emirhan", "Bertuğ", "Efecan", "Atakan", "Taylan",
                "Taha", "Ahmed", "Kutlu", "Ravil", "Recep", "Efe", "Kubilay", "Aral", "Hamza", "Mithat",
                "Baran", "Cihan", "Ertuğrul", "Sefa", "Bilal", "Rahmi", "Necip", "Kadir", "Zafer", "Yasin",
                "Muhammed", "Eyüp", "Enis", "Melih", "Bora", "Koray", "Erkan", "Erdem", "Erhan", "Ercan",
                "Engin", "Egemen", "Ekrem", "Emin", "Erol", "Yasir", "Sercan", "Sadık", "Mücahit", "Musa",
                "Recai", "Arif", "Anıl", "Atilla", "Aytaç", "Ayhan", "Aziz", "Bahadır", "Bekir", "Berkan",
                "Berkay", "Burhan", "Cemal", "Cem", "Cemil", "Cevdet", "Çağatay", "Çağdaş", "Dorukhan", "Durmuş",
                "Emrah", "Ender", "Erce", "Ertan", "Eyüphan", "Faruk", "Ferhat", "Fikret", "Gökay", "Göktan",
                "Görkem", "Güven", "Hayrettin", "Haydar", "İlhan", "İlker", "İlkay", "İsa", "Kamil", "Kemal",
                "Levent", "Mehmetcan", "Melikşah", "Metin", "Nazım", "Necati", "Nuri", "Oktay", "Orhan", "Ömercan",
                "Özgür", "Ramazan", "Sadettin", "Sami", "Savaş", "Selahattin", "Serhat", "Sertaç", "Sezer", "Soner",
                "Suat", "Süleyman", "Şener", "Şenol", "Tamer", "Tayfun", "Tayfur", "Tunahan", "Turgay", "Umutcan",
                "Ufuk", "Yakup", "Yavuz", "Yekta", "Yıldıray", "Zekeriya", "Ziya", "Abdullah", "Adem", "Ahmetcan",
                "Alihan", "Alpaslan", "Arslan", "Aykut", "Aydın", "Berkant", "Bertan", "Burakcan", "Cihat", "Ertunç",
                "Eymen", "Fırat", "Gürkan", "Hasancan", "Kadem", "Kartal", "Kemalettin", "Kutay", "Mirza", "Mustafacan",
                "Nedim", "Oğulcan", "Rahman", "Rıza", "Selman", "Tahsin", "Tolgay", "Vedat", "Yağız", "Yiğithan",
                "Yücel", "Zübeyir", "Aras", "Atahan", "Berke", "Doruk", "Emir", "Ensar", "Metehan", "Poyraz"
            ],
            [
                "Yılmaz", "Kaya", "Demir", "Çelik", "Şahin", "Yıldız", "Yıldırım", "Öztürk", "Aydın", "Özdemir",
                "Arslan", "Doğan", "Kılıç", "Aslan", "Çetin", "Kara", "Koç", "Kurt", "Özkan", "Şimşek",
                "Polat", "Acar", "Aksoy", "Akar", "Bulut", "Kaplan", "Erdoğan", "Güneş", "Bozkurt", "Taş",
                "Akın", "Akgül", "Akbaş", "Aktaş", "Altun", "Ateş", "Avcı", "Aydemir", "Balcı", "Baysal",
                "Başaran", "Bayram", "Bilgin", "Bozdoğan", "Çakır", "Çalhanoğlu", "Coşkun", "Duman", "Durmaz", "Ekinci",
                "Elmas", "Erkan", "Erdem", "Ersoy", "Ertürk", "Gök", "Gökçe", "Gül", "Güler", "Gündoğan",
                "Gürbüz", "Işık", "Karaca", "Karakaya", "Karataş", "Keskin", "Kocaman", "Korkmaz", "Kocabaş", "Kökçü",
                "Kurtuluş", "Metin", "Oral", "Önal", "Özcan", "Özer", "Özgür", "Özbek", "Özkaya", "Öztekin",
                "Sarı", "Sevim", "Soylu", "Sönmez", "Tekin", "Toprak", "Tosun", "Tufan", "Tunç", "Turan",
                "Uçar", "Ünal", "Uysal", "Uzun", "Yalçın", "Yavuz", "Yazıcı", "Yiğit", "Yüksel", "Zengin"
            ]),

        [Country.Germany] = new(
            [
                "Lukas", "Leon", "Jonas", "Felix", "Niklas", "Maximilian", "Paul", "Elias", "Ben", "Luca",
                "Finn", "Tim", "Jan", "Moritz", "Julian", "Tobias", "Florian", "Sebastian", "Thomas", "Michael",
                "Adolf", "Daniel", "Stefan", "Andreas", "Matthias", "Markus", "Kai", "Leroy", "Joshua", "Mats",
                "Manuel", "Toni", "Marco", "Mario", "Jonathan", "David", "Philipp", "Benedikt", "Robin", "Kevin",
                "Dennis", "Pascal", "Nico", "Lars", "Sven", "Dominik", "Fabian", "Marvin", "Jannik", "Henrik",
                "Ilkay", "Antonio", "Jamal", "Serge", "Niclas", "Karim", "Deniz", "Marc-André", "Bernd", "Oliver",
                "Timo", "Lennart", "Benjamin", "Christian", "Nils", "Jens", "Malik", "Youssoufa", "Jerome", "Mesut",
                "Sami", "Shkodran", "Lothar", "Rudi", "Jürgen", "Klaus", "Uwe", "Dieter", "Ralf", "Günter",
                "Rainer", "Wolfgang", "Harald", "Holger", "Torsten", "Jörg", "Thorsten", "Frank", "Carsten", "Steffen",
                "Mike", "Heiko", "Ingo", "Marcel", "René", "Patrick", "Christoph", "Alexander", "Johannes", "Simon",
                "Lennard", "Noah", "Luis", "Max", "Tom", "Erik", "Mattis", "Nick", "Jakob", "Hannes",
                "Ole", "Bastian", "Arne", "Till", "Malte", "Linus", "Henri", "Anton", "Emil", "Theo",
                "Konstantin", "Vincent", "Valentin", "Aaron", "Fynn", "Luka", "Levin", "Jannis", "Jonah", "Mika",
                "Yannick", "Kilian", "Lasse", "Nathaniel", "Marius", "Marlon", "Merlin", "Niko", "Oskar", "Raphael",
                "Rouven", "Silas", "Torben", "Yann", "Jamie", "Tiago", "Timothy", "Sandro", "Armel", "Hendrik",
                "Gerrit", "Wilhelm", "Friedrich", "Karl", "Ludwig", "Georg", "Martin", "Peter", "Ralph", "Stephan",
                "Sascha", "Mirko", "André", "Björn", "Danny", "Enrico", "Hans", "Lutz", "Norbert", "Rolf",
                "Volker", "Waldemar", "Bernhard", "Gregor", "Leonard", "Damian", "Dario", "Denis", "Eric", "Gideon",
                "Kenan", "Mahmoud", "Ömer", "Mustafa", "Mehmet", "Cem", "Can", "Kerem", "Ali", "Ibrahim",
                "Yusuf", "Ismail", "Ahmed", "Hamza", "Bilal", "Amin", "Mohamed", "Nadiem", "Suat", "Ermedin",
                "Armin", "Edin", "Mergim", "Arijon", "Elvis", "Ilir", "Jeremiah", "Josha", "Prince", "Samuel",
                "Tyler", "Jayden", "Jordan", "Elijah", "Joel", "Noel", "Dominique", "Thilo", "Gerd", "Helmut",
                "Horst", "Willi", "Alfred", "Werner", "Erich", "Heinz", "Mathis", "Konrad", "Leopold", "Rüdiger",
                "Gerald", "Detlef", "Ernst", "Hartmut", "Kurt", "Gerhard", "Reinhard", "Joachim", "Achim", "Hans-Jürgen",
                "Ulrich", "Dietmar", "Eike", "Lennox", "Timon", "Laurin", "Jona", "Bennet", "Lion", "Collin"
            ],
            [
                "Müller", "Schmidt", "Schneider", "Fischer", "Weber", "Meyer", "Wagner", "Becker", "Schulz", "Hoffmann",
                "Schäfer", "Koch", "Bauer", "Richter", "Klein", "Wolf", "Schröder", "Neumann", "Schwarz", "Zimmermann",
                "Braun", "Krüger", "Hofmann", "Hartmann", "Lange", "Schmitt", "Werner", "Krause", "Meier", "Lehmann",
                "Kroos", "Neuer", "Gündoğan", "Kimmich", "Goretzka", "Havertz", "Sané", "Gnabry", "Rüdiger", "Draxler",
                "Hummels", "Boateng", "Reus", "Götze", "Schürrle", "Lahm", "Schweinsteiger", "Klose", "Podolski", "Mertesacker",
                "Ballack", "Kahn", "Matthäus", "Völler", "Brandt", "Wirtz", "Musiala", "Füllkrug", "Schlotterbeck", "Tah",
                "Raum", "Andrich", "Gross", "Undav", "Mittelstädt", "Beier", "Baumann", "Nübel", "Trapp", "Ter Stegen",
                "Leno", "Schulze", "Herrmann", "Hahn", "Vogt", "Keller", "Frank", "Berger", "Huber", "Kaiser",
                "Fuchs", "Peters", "Lang", "Scholz", "Jung", "Ludwig", "Franke", "Roth", "Beck", "Lorenz",
                "Graf", "Kraus", "Böhm", "Busch", "Thomas", "Winkler", "Schuster", "Albrecht", "Simon", "Schreiber"
            ]),

        [Country.France] = new(
            [
                "Antoine", "Hugo", "Lucas", "Théo", "Kylian", "Paul", "Olivier", "Raphaël", "Benjamin", "Adrien",
                "Mathis", "Louis", "Gabriel", "Arthur", "Jules", "Nathan", "Thomas", "Maxime", "Alexandre", "Julien",
                "Nicolas", "Pierre", "Florian", "Romain", "Clément", "Baptiste", "Quentin", "Valentin", "Guillaume", "Jérémy",
                "Kévin", "Mathieu", "Aurélien", "Léo", "Ethan", "Noah", "Enzo", "Matteo", "Tom", "Sacha",
                "Rayan", "Yanis", "Ousmane", "Moussa", "Bastien", "Dayot", "Ibrahima", "Warren", "Randal", "Corentin",
                "N'Golo", "Marcus", "Kingsley", "William", "Mike", "Bradley", "Christopher", "Youssouf", "Mattéo", "Michael",
                "Khéphren", "Jean-Philippe", "Jean", "Benoît", "Zinedine", "Thierry", "Didier", "Laurent", "Fabien", "Lilian",
                "Marcel", "Patrice", "Bixente", "Robert", "Claude", "Emmanuel", "Sylvain", "Franck", "Samir", "Karim",
                "Hatem", "Loïc", "Djibril", "Blaise", "Steve", "Yohan", "Morgan", "Mamadou", "Nabil", "Mehdi",
                "Wissam", "Sofiane", "Ilyes", "Ryan", "Amine", "Bilal", "Adam", "Yacine", "Mohamed", "Abdou",
                "Boubacar", "Cheick", "Alassane", "Amadou", "Oumar", "Issa", "Lassana", "Sékou", "Tiémoué", "Eliaquim",
                "Axel", "Wesley", "Jonathan", "Alexis", "Anthony", "Benoit", "Cédric", "Christophe", "Damien", "Fabrice",
                "Grégory", "Jérôme", "Jordan", "Mickaël", "Sébastien", "Stéphane", "Thibault", "Thibaut", "Vincent", "Xavier",
                "Yann", "Yoann", "Rémi", "Rémy", "Lionel", "Ludovic", "Frédéric", "Hervé", "Gaël", "Gaëtan",
                "Mathys", "Maxence", "Lenny", "Timothé", "Evan", "Noé", "Esteban", "Elias", "Léon", "Malo",
                "Gabin", "Martin", "Victor", "Simon", "Robin", "Félix", "Rafael", "Nolan", "Kenzo", "Wilfried",
                "Jean-Clair", "Lucien", "Loris", "Mathéo", "Marius", "Loan", "Tanguy", "Alban", "Nathanaël", "Amaury",
                "Gauthier", "Cyril", "Matthieu", "Arnaud", "Boris", "Bruno", "Denis", "Florent", "Jérémie", "Joris",
                "Pierre-Emerick", "Pierre-Emile", "Jean-Kévin", "Steven", "Wahbi", "Hamza", "Ismaël", "Achraf", "Youcef", "Riyad",
                "Rachid", "Abdelhamid", "Saïd", "Farid", "Walid", "Kader", "Souleymane", "Ibrahim", "Idrissa", "Abdoulaye",
                "Lamine", "Mouhamadou", "Alpha", "Ismaïla", "Aliou", "Thierno", "Bakary", "Bouna", "Pape", "Sadio",
                "Dimitri", "Lassine", "Brice", "Kelvin", "Nampalys", "Neal", "Antonin", "Cyprien", "Lorenzo", "Logan",
                "Mattis", "Jason", "Dylan", "Kenny", "Mathias", "Tristan", "Bryan", "Alain", "Jean-Pierre", "Patrick",
                "Philippe", "Bernard", "Gilles", "Yves", "Hugues", "Jacques", "Jean-Charles", "Jean-Victor", "Kays", "Maël",
                "Lohann", "Ewen", "Ayoub", "Anis", "Nassim", "Karl", "Brahim", "Soufiane", "Yassine", "Rafik"
            ],
            [
                "Martin", "Bernard", "Dubois", "Thomas", "Robert", "Richard", "Petit", "Durand", "Leroy", "Moreau",
                "Simon", "Laurent", "Lefebvre", "Michel", "Garcia", "David", "Bertrand", "Roux", "Vincent", "Fournier",
                "Morel", "Girard", "André", "Lefèvre", "Mercier", "Dupont", "Lambert", "Bonnet", "François", "Martinez",
                "Griezmann", "Mbappé", "Pogba", "Kanté", "Varane", "Lloris", "Giroud", "Dembélé", "Tchouaméni", "Camavinga",
                "Konaté", "Upamecano", "Koundé", "Hernandez", "Rabiot", "Kolo Muani", "Thuram", "Saliba", "Maignan", "Coman",
                "Benzema", "Zidane", "Henry", "Deschamps", "Blanc", "Desailly", "Vieira", "Ribéry", "Nasri", "Malouda",
                "Abidal", "Evra", "Sagna", "Clichy", "Mandanda", "Lacazette", "Fekir", "Payet", "Martial", "Digne",
                "Pavard", "Lemar", "Tolisso", "Matuidi", "Cabaye", "Gameiro", "Rémy", "Sissoko", "Gignac", "Valbuena",
                "Ménez", "Ben Arfa", "Mathieu", "Gaillard", "Fontaine", "Chevalier", "Roussel", "Blanchard", "Gauthier", "Perrin",
                "Guerin", "Boyer", "Garnier", "Faure", "Rousseau", "Dumont", "Lemaire", "Fabre", "Colin", "Brun"
            ]),

        [Country.Italy] = new(
            [
                "Alessandro", "Lorenzo", "Matteo", "Andrea", "Francesco", "Leonardo", "Gabriele", "Riccardo", "Tommaso", "Edoardo",
                "Federico", "Giuseppe", "Antonio", "Marco", "Luca", "Davide", "Simone", "Stefano", "Giovanni", "Roberto",
                "Paolo", "Fabio", "Daniele", "Nicolò", "Gianluigi", "Ciro", "Domenico", "Salvatore", "Vincenzo", "Mattia",
                "Filippo", "Pietro", "Giacomo", "Emanuele", "Christian", "Manuel", "Giorgio", "Mario", "Claudio", "Massimo",
                "Alberto", "Sandro", "Gianluca", "Samuele", "Michele", "Diego", "Alessio", "Cristiano", "Raffaele", "Valerio",
                "Wilfried", "Gennaro", "Luigi", "Carmine", "Pasquale", "Gaetano", "Angelo", "Nicola", "Fabrizio", "Mauro",
                "Maurizio", "Sergio", "Giampaolo", "Gianfranco", "Gianmarco", "Giancarlo", "Pierluigi", "Pierpaolo", "Piero", "Enrico",
                "Ernesto", "Ettore", "Elia", "Eduardo", "Dario", "Cristian", "Cesare", "Carlo", "Bruno", "Antonino",
                "Alfredo", "Aldo", "Adriano", "Amedeo", "Arturo", "Attilio", "Aurelio", "Bartolomeo", "Bernardo", "Biagio",
                "Calogero", "Camillo", "Cosimo", "Damiano", "Dino", "Duccio", "Elio", "Enzo", "Fausto", "Felice",
                "Ferdinando", "Flavio", "Franco", "Gerardo", "Giacinto", "Gino", "Giulio", "Graziano", "Guido", "Ignazio",
                "Ivan", "Jacopo", "Lapo", "Leandro", "Lino", "Livio", "Lucio", "Manolo", "Marcello", "Mariano",
                "Marino", "Martino", "Mirko", "Nazzareno", "Nunzio", "Orazio", "Oreste", "Ottavio", "Patrizio", "Raimondo",
                "Remo", "Renato", "Renzo", "Rocco", "Rodolfo", "Romeo", "Rosario", "Ruggero", "Sabatino", "Santo",
                "Saverio", "Sebastiano", "Silvio", "Teodoro", "Tiziano", "Ugo", "Umberto", "Valentino", "Vittorio", "Walter",
                "Zeno", "Gioele", "Christopher", "Kevin", "Thomas", "Nicolas", "Denis", "Moreno", "Morgan", "Iacopo",
                "Ludovico", "Tancredi", "Brando", "Alex", "Mirco", "Lauro", "Tito", "Pellegrino", "Vito", "Achille",
                "Ercole", "Marzio", "Arnaldo", "Aniello", "Giuliano", "Gianni", "Massimiliano", "Corrado", "Costantino", "Cristoforo",
                "Raffaello", "Rinaldo", "Settimo", "Primo", "Pio", "Mattias", "Lucas", "Michael", "Fiorenzo", "Ezio",
                "Egidio", "Ennio", "Natale", "Osvaldo", "Silvano", "Sauro", "Severino", "Tullio", "Vasco", "Dante",
                "Daniel", "Gianpiero", "Leone", "Luciano", "Matias", "Noah", "Thiago", "Yuri", "Eugenio", "Fernando",
                "Gianmaria", "Giordano", "Lazzaro", "Leopoldo", "Marcantonio", "Maurilio", "Pierfrancesco", "Rosolino", "Salvo", "Silvestro",
                "Stanislao", "Tobia", "Ubaldo", "Virgilio", "Mattheo", "Giosuè", "Gianvito", "Antonello", "Agostino", "Nazario",
                "Annibale", "Ilario", "Ivano", "Loris", "Eros", "Kristian", "Fulvio", "Adelio", "Cirino", "Donato",
                "Giampiero", "Giandomenico", "Romolo", "Ruben", "Leo", "Nico", "Manuele", "Gaspare", "Benedetto", "Girolamo"
            ],
            [
                "Rossi", "Russo", "Ferrari", "Esposito", "Bianchi", "Romano", "Colombo", "Ricci", "Marino", "Greco",
                "Bruno", "Gallo", "Conti", "De Luca", "Mancini", "Costa", "Giordano", "Rizzo", "Lombardi", "Moretti",
                "Barbieri", "Fontana", "Santoro", "Mariani", "Rinaldi", "Caruso", "Ferrara", "Galli", "Martini", "Leone",
                "Donnarumma", "Bonucci", "Chiellini", "Barella", "Verratti", "Insigne", "Immobile", "Chiesa", "Bastoni", "Di Lorenzo",
                "Dimarco", "Frattesi", "Tonali", "Scamacca", "Retegui", "Raspadori", "Pellegrini", "Calafiori", "Buongiorno", "Cambiaso",
                "Locatelli", "Florenzi", "Spinazzola", "Acerbi", "Bernardeschi", "Belotti", "Zaniolo", "Vicario", "Carnesecchi", "Gatti",
                "Udogie", "Orsolini", "Pirlo", "Totti", "Del Piero", "Buffon", "Cannavaro", "Nesta", "Maldini", "Baresi",
                "Baggio", "Vieri", "Gattuso", "De Rossi", "Inzaghi", "Toni", "Gilardino", "Materazzi", "Zambrotta", "Grosso",
                "Barzagli", "Montolivo", "Marchisio", "Candreva", "Pazzini", "Cassano", "Balotelli", "Sirigu", "Darmian", "Ogbonna",
                "Romagnoli", "Bellanova", "Fagioli", "Lucca", "Ferri", "Serra", "Villa", "Farina", "Sala", "Fabbri"
            ]),

        [Country.Spain] = new(
            [
                "Alejandro", "Pablo", "Daniel", "David", "Adrián", "Javier", "Sergio", "Carlos", "Álvaro", "Diego",
                "Iker", "Mario", "Hugo", "Marcos", "Rubén", "Raúl", "Fernando", "Andrés", "Xavi", "Gerard",
                "Jordi", "Marc", "Pedro", "Jesús", "Francisco", "Manuel", "Antonio", "José", "Juan", "Luis",
                "Miguel", "Ángel", "Rodrigo", "Nacho", "Unai", "Mikel", "Aitor", "Ander", "Pau", "Ferran",
                "Nico", "Iñaki", "Santiago", "Jorge", "Óscar", "Víctor", "Ismael", "Joan", "Martín", "Borja",
                "Dani", "Fabián", "Marco", "Lamine", "Fermín", "Gavi", "Ansu", "Carles", "Xabi", "Fran",
                "Joselu", "Ayoze", "Aleix", "Isco", "Koke", "Saúl", "Thiago", "Santi", "Cesc", "Gonzalo",
                "Brahim", "Yeremy", "Yeray", "Oihan", "Eric", "Iñigo", "Jon", "Julen", "Gorka", "Asier",
                "Ibai", "Imanol", "Jokin", "Xabier", "Aritz", "Beñat", "Eneko", "Oier", "Endika", "Igor",
                "Josu", "Markel", "Urko", "Aimar", "Ekain", "Unax", "Hodei", "Mattin", "Eder", "Aaron",
                "Jaume", "Josep", "Arnau", "Pol", "Oriol", "Roger", "Guillem", "Biel", "Ot", "Albert",
                "Xavier", "Martí", "Nil", "Quim", "Toni", "Joaquín", "Juanma", "Juanmi", "Juanfran", "Juanjo",
                "Manu", "Paco", "Pepe", "Chema", "Kike", "Quique", "Rafa", "Lucas", "Javi", "Héctor",
                "Iván", "Jaime", "Ignacio", "Rafael", "Ramón", "Roberto", "Samuel", "Tomás", "Vicente", "Bernardo",
                "Álex", "Abel", "Adolfo", "Agustín", "Alberto", "Alfonso", "Alfredo", "Anselmo", "Arturo", "Benjamín",
                "Bruno", "Cristian", "Cristóbal", "Darío", "Domingo", "Eduardo", "Emilio", "Enrique", "Ernesto", "Esteban",
                "Eugenio", "Federico", "Felipe", "Félix", "Germán", "Gregorio", "Guillermo", "Gustavo", "Jacobo", "Julián",
                "Julio", "Leandro", "Leonardo", "Lorenzo", "Marcelino", "Mariano", "Mateo", "Matías", "Mauro", "Maximiliano",
                "Nicolás", "Pascual", "Patricio", "Raimundo", "Ricardo", "Salvador", "Sebastián", "Simón", "Teodoro", "Valentín",
                "Ezequiel", "Fausto", "Gael", "Izan", "Bryan", "Joel", "Iago", "Brais", "Xoán", "Uxío",
                "Martiño", "Antón", "Breogán", "Cristo", "Juanlu", "Pepelu", "Rodri", "Riqui", "Samu", "Sandro",
                "Andoni", "Txema", "Jonathan", "Kepa", "Ángelo", "Edu", "Hernán", "Tito", "Alfon", "Leo",
                "Alexis", "Juanito", "Gabri", "Nando", "Fede", "Curro", "Lalo", "Paulino", "Sergi", "Adri",
                "Jairo", "Gerardo", "Hernani", "Fidel", "Marcelo", "Isaac", "Erik", "Alejo", "Eloy", "Genís",
                "Lluís", "Pere", "Ignasi", "Eloi", "Joaquim", "Telmo", "Lander", "Marcial", "Cayetano", "Baltasar"
            ],
            [
                "García", "Rodríguez", "González", "Fernández", "López", "Martínez", "Sánchez", "Pérez", "Gómez", "Martín",
                "Jiménez", "Ruiz", "Hernández", "Díaz", "Moreno", "Muñoz", "Álvarez", "Romero", "Alonso", "Gutiérrez",
                "Navarro", "Torres", "Domínguez", "Vázquez", "Ramos", "Gil", "Ramírez", "Serrano", "Blanco", "Molina",
                "Busquets", "Piqué", "Puyol", "Iniesta", "Casillas", "Valdés", "Reina", "Villa", "Silva", "Cazorla",
                "Fàbregas", "Alba", "Olmo", "Merino", "Oyarzabal", "Morata", "Asensio", "Ferrán", "Laporte", "Cucurella",
                "Grimaldo", "Zubimendi", "Le Normand", "Vivian", "Raya", "Remiro", "Simón", "Sarabia", "Pino", "Baena",
                "Ceballos", "Soler", "Llorente", "Arteta", "Albiol", "Marchena", "Capdevila", "Guardiola", "Hierro", "Zubizarreta",
                "Salinas", "Guerrero", "Mendieta", "Morientes", "Luque", "Bravo", "Castillo", "Cortés", "Delgado", "Durán",
                "Fuentes", "Herrera", "Iglesias", "Lozano", "Márquez", "Medina", "Méndez", "Mora", "Nieto", "Núñez",
                "Ortega", "Ortiz", "Pascual", "Peña", "Prieto", "Rubio", "Sáez", "Santos", "Sanz", "Soto"
            ]),

        [Country.England] = new(
            [
                "Harry", "Jack", "Oliver", "George", "Charlie", "Thomas", "James", "William", "Joshua", "Daniel",
                "Jordan", "Marcus", "Raheem", "Jude", "Phil", "Bukayo", "Declan", "Mason", "Kyle", "Kieran",
                "John", "Luke", "Ben", "Aaron", "Callum", "Conor", "Reece", "Trent", "Jadon", "Cole",
                "Ollie", "Eberechi", "Jarrod", "Ezri", "Levi", "Morgan", "Ivan", "Ryan", "Lewis", "Sam",
                "Joe", "Matthew", "Liam", "Adam", "Nathan", "Tyler", "Alfie", "Freddie", "Archie", "Henry",
                "Jamie", "Danny", "Michael", "Steven", "Frank", "Wayne", "Gary", "Paul", "David", "Peter",
                "Andrew", "Mark", "Richard", "Robert", "Christopher", "Chris", "Anthony", "Stephen", "Craig", "Lee",
                "Darren", "Jason", "Dean", "Scott", "Stuart", "Neil", "Ian", "Martin", "Simon", "Ashley",
                "Wes", "Jermain", "Theo", "Alex", "Max", "Oscar", "Harvey", "Louie", "Toby", "Dominic",
                "Emile", "Rhys", "Jacob", "Ethan", "Noah", "Leo", "Finley", "Elliot", "Elliott", "Jonjo",
                "Jesse", "Tammy", "Ebere", "Curtis", "Jarell", "Kalvin", "Fikayo", "Tino", "Rico", "Kobbie",
                "Jaden", "Jayden", "Kai", "Tayo", "Ademola", "Folarin", "Chuba", "Emmanuel", "Samuel", "Benjamin",
                "Joel", "Isaac", "Josh", "Owen", "Jake", "Brandon", "Kane", "Kian", "Lloyd", "Dwight",
                "Ross", "Jordon", "Tom", "Will", "Billy", "Bobby", "Tommy", "Sonny", "Jay", "Kevin",
                "Ricky", "Carl", "Gareth", "Glenn", "Nicky", "Jonathan", "Tim", "Nick", "Rob", "Joey",
                "Taylor", "Ellis", "Brennan", "Jarrad", "Marc", "Nathaniel", "Raphael", "Ashton", "Malik", "Omari",
                "Kenny", "Jamal", "Yasin", "Hamza", "Mohammed", "Zak", "Zach", "Imran", "Adil", "Kasey",
                "Dion", "Andre", "Jermaine", "Darnell", "Tyrese", "Tyrone", "Jerome", "Leon", "Leroy", "Tariq",
                "Cameron", "Bradley", "Jonny", "Aiden", "Harrison", "Reuben", "Ruben", "Louis", "Sean", "Shaun",
                "Mikey", "Lucas", "Mateo", "Rio", "Sol", "Jobe", "Tyrick", "Djed", "Myles", "Tobi",
                "Ayo", "Femi", "Jeremie", "Kenneth", "Kaine", "Noni", "Jamaal", "Bashir", "Adebayo", "Chinedu",
                "Obi", "Dele", "Victor", "Felix", "Rasmus", "Hayden", "Elijah", "Gabriel", "Jonah", "Ezra",
                "Rory", "Stanley", "Arthur", "Teddy", "Albie", "Hugo", "Austin", "Roman", "Rocco", "Rafe",
                "Zane", "Riley", "Mitchell", "Duncan", "Lyle", "Brooklyn", "Romeo", "Edward", "Ted", "Jonjoe",
                "Kieron", "Kenji", "Kofi", "Kwame", "Kelechi", "Kingsley", "Quincy", "Chiedozie", "Kurtis", "Brad"
            ],
            [
                "Smith", "Jones", "Williams", "Taylor", "Brown", "Davies", "Evans", "Wilson", "Thomas", "Johnson",
                "Roberts", "Robinson", "Thompson", "Wright", "Walker", "White", "Edwards", "Hughes", "Green", "Hall",
                "Lewis", "Harris", "Clarke", "Patel", "Jackson", "Wood", "Turner", "Martin", "Cooper", "Hill",
                "Ward", "Morris", "Moore", "Clark", "Lee", "King", "Baker", "Harrison", "Morgan", "Allen",
                "James", "Scott", "Phillips", "Watson", "Davis", "Parker", "Price", "Bennett", "Young", "Griffiths",
                "Mitchell", "Kelly", "Cook", "Carter", "Richardson", "Bailey", "Collins", "Bell", "Shaw", "Murphy",
                "Miller", "Cox", "Richards", "Khan", "Marshall", "Anderson", "Simpson", "Ellis", "Adams", "Singh",
                "Begum", "Wilkinson", "Foster", "Chapman", "Powell", "Webb", "Rogers", "Gray", "Mason", "Ali",
                "Hunt", "Hussain", "Campbell", "Matthews", "Owen", "Palmer", "Holmes", "Mills", "Barnes", "Knight",
                "Lloyd", "Butler", "Russell", "Barker", "Fisher", "Stevens", "Jenkins", "Murray", "Dixon", "Harvey"
            ]),

        [Country.Brazil] = new(
            [
                "Gabriel", "Lucas", "Matheus", "Pedro", "Guilherme", "Rafael", "Felipe", "Gustavo", "João", "Thiago",
                "Bruno", "Vinícius", "Rodrigo", "Diego", "Leonardo", "Eduardo", "Carlos", "Marcelo", "Fernando", "Ricardo",
                "Paulo", "André", "Fábio", "Douglas", "Danilo", "Alisson", "Ederson", "Casemiro", "Fabinho", "Raphinha",
                "Richarlison", "Neymar", "Endrick", "Éder", "Wesley", "Willian", "Roberto", "Ronaldo", "Romário", "Rivaldo",
                "Kaká", "Júlio", "Luiz", "Renan", "Igor", "Caio", "Davi", "Arthur", "Samuel", "Murilo",
                "Miguel", "Heitor", "Bernardo", "Enzo", "Lorenzo", "Nicolas", "Henrique", "Vitor", "Victor", "Daniel",
                "Antônio", "Francisco", "José", "Marcos", "Márcio", "Sérgio", "Alexandre", "Leandro", "Luciano", "Adriano",
                "Anderson", "Alex", "Alan", "Allan", "Everton", "Gerson", "Hulk", "Jorginho", "Juninho", "Ronaldinho",
                "Rivelino", "Sócrates", "Zico", "Cafu", "Dunga", "Bebeto", "Emerson", "Gilberto", "Roque", "Fred",
                "Oscar", "Paulinho", "Lucão", "Marquinhos", "Militão", "Thiaguinho", "Pepê", "Antony", "Rodrygo", "Martinelli",
                "Savinho", "Estêvão", "Vitinho", "Luan", "Hernanes", "Elias", "Ramires", "Renato", "Rogério", "Cássio",
                "Weverton", "Bento", "Hugo", "Rony", "Dudu", "Raniel", "Rafinha", "Abel", "Cleiton", "Cleber",
                "Kléber", "Wellington", "Washington", "Jefferson", "Jhon", "Jonathan", "Jean", "Joelinton", "Matheuzinho", "Patrick",
                "Talles", "Yuri", "Ygor", "Kaio", "Kauã", "Kauan", "Kayky", "Kaiky", "Ryan", "Wendell",
                "Weslley", "Rodinei", "Fagner", "Alexsandro", "Ayrton", "Reinier", "Otávio", "Augusto", "Valdir", "Marlon",
                "Maurício", "Wanderson", "Robson", "Edson", "Nilton", "Ailton", "Adílson", "Wilson", "Nélson", "Gilson",
                "Jair", "Jairzinho", "Tostão", "Zé", "Mateus", "Nathan", "Breno", "Bruninho", "Yan", "Ian",
                "Iago", "Thalles", "Michael", "Mário", "Joaquim", "Benjamin", "Isaac", "Emanuel", "Lázaro", "Gilmar",
                "Cícero", "Tiago", "Thalisson", "Kenedy", "Lyanco", "Léo", "Lucca", "Luca", "Raul", "Saulo",
                "Wagner", "Walace", "Ronald", "Juan", "Natan", "Nino", "Fabrício", "Fabiano", "Flávio", "Giovanni",
                "Heverton", "Jemerson", "Juliano", "Kevin", "Lincoln", "Luís", "Messias", "Moisés", "Nenê", "Pablo",
                "Pierre", "Rômulo", "Sávio", "Taison", "Thierry", "Tchê", "Vanderlei", "Vágner", "Welington", "William",
                "Yago", "Zeca", "Bremer", "Gleison", "Rayan", "Deyverson", "Diogo", "Elkeson", "Erick", "Erison",
                "Everaldo", "Felipinho", "Hélio", "Ítalo", "Jadson", "Jô", "Leonan", "Maycon", "Mayke", "Nathanael",
                "Rhuan", "Ruan", "Thalys", "Vinny", "Wanderley", "Joílson", "Jonas", "Geovane", "Denílson", "Kleberson"
            ],
            [
                "Silva", "Santos", "Oliveira", "Souza", "Rodrigues", "Ferreira", "Alves", "Pereira", "Lima", "Gomes",
                "Costa", "Ribeiro", "Martins", "Carvalho", "Almeida", "Lopes", "Soares", "Fernandes", "Vieira", "Barbosa",
                "Rocha", "Dias", "Nascimento", "Andrade", "Moreira", "Nunes", "Marques", "Machado", "Mendes", "Freitas",
                "Cardoso", "Ramos", "Gonçalves", "Santana", "Teixeira", "Araújo", "Monteiro", "Moura", "Correia", "Pinto",
                "Cavalcanti", "Batista", "Campos", "Castro", "Cunha", "Pires", "Reis", "Borges", "Brito", "Azevedo",
                "Melo", "Coelho", "Guimarães", "Sousa", "Farias", "Miranda", "Medeiros", "Viana", "Xavier", "Fonseca",
                "Duarte", "Bezerra", "Cruz", "Pinheiro", "Tavares", "Siqueira", "Moraes", "Barros", "Peixoto", "Queiroz",
                "Neves", "Paiva", "Leite", "Macedo", "Matos", "Aguiar", "Rezende", "Prado", "Lacerda", "Sampaio",
                "Magalhães", "Bastos", "Vasconcelos", "Brandão", "Bittencourt", "Assis", "Sales", "Jesus", "Conceição", "Domingues",
                "Amaral", "Fagundes", "Figueiredo", "Godoy", "Toledo", "Mota", "Fontes", "Lemos", "Salgado", "Franco"
            ]),

        [Country.Argentina] = new(
            [
                "Lionel", "Ángel", "Sergio", "Gonzalo", "Julián", "Lautaro", "Rodrigo", "Alexis", "Enzo", "Emiliano",
                "Nicolás", "Cristian", "Nahuel", "Leandro", "Lisandro", "Germán", "Marcos", "Paulo", "Giovani", "Ezequiel",
                "Javier", "Gabriel", "Mauro", "Matías", "Facundo", "Franco", "Thiago", "Valentín", "Santiago", "Agustín",
                "Tomás", "Juan", "Martín", "Diego", "Carlos", "Fernando", "Hernán", "Esteban", "Maximiliano", "Gastón",
                "Lucas", "Joaquín", "Ignacio", "Alejandro", "Federico", "Exequiel", "Guido", "Leonardo", "Pablo", "Ramiro",
                "Bautista", "Benjamín", "Mateo", "Felipe", "Lorenzo", "Bruno", "Francisco", "Manuel", "Andrés", "Jorge",
                "Luis", "José", "Miguel", "Daniel", "Damián", "Darío", "Sebastián", "Mariano", "Lucio", "Claudio",
                "Gustavo", "Gerardo", "Guillermo", "Ricardo", "Roberto", "Raúl", "Rubén", "Ramón", "Oscar", "Osvaldo",
                "Ariel", "Walter", "Hugo", "Héctor", "Horacio", "Jonathan", "Jonatan", "Brian", "Kevin", "Alan",
                "Axel", "Iván", "Marcelo", "Mario", "Mauricio", "Mirko", "Milton", "Nehuén", "Nazareno", "Octavio",
                "Patricio", "Pedro", "Renzo", "Rolando", "Valentino", "Victor", "Fausto", "Fabricio", "Fabián", "Emanuel",
                "Emmanuel", "Elías", "Eduardo", "Dylan", "Cristián", "Christian", "Brandon", "Braian", "Alexander", "Adolfo",
                "Aníbal", "Ayrton", "Leonel", "Lucca", "Luciano", "Julio", "Jeremías", "Jerónimo", "Ian", "Gianluca",
                "Gerónimo", "Gian", "Fernán", "Erik", "Enrique", "Elian", "Dante", "Cristóbal", "Ciro", "César",
                "Camilo", "Bernardo", "Augusto", "Armando", "Alfredo", "Alberto", "Adrián", "Abel", "Aarón", "Tobías",
                "Tiago", "Simón", "Santino", "Salvador", "Rodolfo", "Rafael", "Néstor", "Natanael", "Moisés", "Marcelino",
                "Joel", "Jonás", "Jesús", "Ismael", "Isaac", "Florián", "Fermín", "Ernesto", "Emilio", "Elio",
                "Edgardo", "Benicio", "Baltasar", "Aldo", "Ulises", "Teo", "Tadeo", "Silvio", "Rogelio", "Reinaldo",
                "Nelson", "Matheo", "Luka", "León", "Lean", "Jano", "Ivo", "Gino", "Gianfranco", "Eric",
                "Eugenio", "Domingo", "Blas", "Aquiles", "Thomas", "Sixto", "Roque", "Rocco", "Paolo", "Omar",
                "Norberto", "Milo", "Máximo", "Lázaro", "Isidro", "Gregorio", "Feliciano", "Evaristo", "Estanislao", "Dardo",
                "Bernabé", "Anselmo", "Américo", "Amadeo", "Alfio", "Abraham", "Valerio", "Ubaldo", "Teodoro", "Santos",
                "Rufino", "Rosendo", "Quintín", "Laureano", "Jacinto", "Hipólito", "Heriberto", "Gualberto", "Gervasio", "Gaspar",
                "Flavio", "Faustino", "Fabio", "Eusebio", "Marco", "Nicola", "Wenceslao", "Marcial", "Teófilo", "Vicente",
                "Liam", "Aitor", "Román", "Mathías", "Gael", "Tiziano", "Bastián", "Vito", "Gianni", "Brahian"
            ],
            [
                "González", "Rodríguez", "Gómez", "Fernández", "López", "Díaz", "Martínez", "Pérez", "García", "Sánchez",
                "Romero", "Sosa", "Álvarez", "Torres", "Ruiz", "Ramírez", "Flores", "Acosta", "Benítez", "Medina",
                "Suárez", "Herrera", "Aguirre", "Pereyra", "Gutiérrez", "Giménez", "Molina", "Silva", "Castro", "Rojas",
                "Ortiz", "Núñez", "Luna", "Juárez", "Cabrera", "Ríos", "Ferreyra", "Godoy", "Morales", "Domínguez",
                "Moreno", "Peralta", "Vega", "Carrizo", "Quiroga", "Castillo", "Ledesma", "Muñoz", "Ojeda", "Ponce",
                "Vera", "Cardozo", "Figueroa", "Correa", "Ramos", "Vázquez", "Coronel", "Ibáñez", "Paz", "Cáceres",
                "Navarro", "Arias", "Mendoza", "Villalba", "Maldonado", "Gallo", "Bustos", "Ferrari", "Rossi", "Russo",
                "Lombardi", "Romano", "Colombo", "Bianchi", "Paredes", "Otamendi", "Palacios", "Montiel", "Tagliafico", "Lo Celso",
                "Di María", "De Paul", "Mac Allister", "Almada", "Barco", "Garnacho", "Buonanotte", "Echeverri", "Mastantuono", "Varela",
                "Sotelo", "Insaurralde", "Ocampos", "Funes", "Chávez", "Ávila", "Toledo", "Miranda", "Escobar", "Aranda"
            ]),

        [Country.Uruguay] = new(
            [
                "Luis", "Edinson", "Diego", "Federico", "Rodrigo", "Ronald", "José", "Darwin", "Facundo", "Matías",
                "Nicolás", "Sebastián", "Agustín", "Maximiliano", "Fernando", "Martín", "Gastón", "Giorgian", "Manuel", "Lucas",
                "Santiago", "Joaquín", "Mathías", "Brian", "Guillermo", "Álvaro", "Cristian", "Marcelo", "Gonzalo", "Bruno",
                "Felipe", "Emiliano", "Ignacio", "Juan", "Pablo", "Gerardo", "Walter", "Carlos", "Jorge", "Andrés",
                "Alejandro", "Franco", "Mauricio", "Leonardo", "Thiago", "Enzo", "Nahitan", "Mateo", "Sergio", "Damián",
                "Fabián", "Christian", "Cristhian", "Gabriel", "Germán", "Guzmán", "Horacio", "Hugo", "Iván", "Jonathan",
                "Kevin", "Leandro", "Lucio", "Marcos", "Mario", "Miguel", "Nahuel", "Néstor", "Omar", "Óscar",
                "Paolo", "Pedro", "Rafael", "Ramiro", "Ramón", "Raúl", "Ricardo", "Roberto", "Rubén", "Salvador",
                "Tabaré", "Tomás", "Valentín", "Víctor", "Washington", "Wilson", "Yonathan", "Adrián", "Alan", "Alex",
                "Alexis", "Alfredo", "Alberto", "Ángel", "Antonio", "Ariel", "Armando", "Augusto", "Axel", "Bautista",
                "Benjamín", "Braian", "Bryan", "Camilo", "César", "Claudio", "Daniel", "Darío", "David", "Denis",
                "Eduardo", "Elías", "Emanuel", "Emmanuel", "Enrique", "Ernesto", "Esteban", "Ezequiel", "Fabricio", "Fausto",
                "Florencio", "Francisco", "Gianni", "Gino", "Hernán", "Héctor", "Iñaki", "Ismael", "Jairo", "Javier",
                "Jeremías", "Joel", "Jonás", "Julián", "Julio", "Leonel", "Lisandro", "Lorenzo", "Luciano", "Mariano",
                "Matheus", "Máximo", "Milton", "Nazareno", "Nelson", "Octavio", "Orlando", "Patricio", "Renzo", "Richard",
                "Rodolfo", "Rómulo", "Santino", "Simón", "Tiago", "Valentino", "Waldemar", "Abel", "Aldo", "Américo",
                "Anderson", "Aníbal", "Bernardo", "Brayan", "Ciro", "Cristóbal", "Dante", "Dylan", "Elbio", "Emilio",
                "Erik", "Fermín", "Florián", "Gianfranco", "Gustavo", "Héber", "Ian", "Isaac", "Jesús", "Jonatan",
                "Lautaro", "León", "Luca", "Lucca", "Matteo", "Mauro", "Miqueas", "Obdulio", "Pascual", "Ronaldo",
                "Santos", "Saúl", "Silvio", "Tadeo", "Teodoro", "Ulises", "Vicente", "Wilmar", "Yamandú", "Zacarías",
                "Alcides", "Atilio", "Baltasar", "Ever", "Nery", "Paulo", "Venancio", "Wílliam", "Yerson", "Ademar",
                "Alfonso", "Arturo", "Carlo", "Danilo", "Edgar", "Efraín", "Elio", "Ezequías", "Fabio", "Félix",
                "Gerónimo", "Giovanni", "Ivo", "Jacinto", "Jeremy", "Josué", "Lázaro", "Liber", "Marcio", "Marco",
                "Norberto", "Osvaldo", "Sandro", "Tobías", "Valerio", "Yuri", "Román", "Gael", "Bastián", "Tiziano",
                "Vito", "Gaspar", "Renato", "Hamilton", "Gianluca", "Marcel", "Christopher", "Brahian", "Erick", "Thomas"
            ],
            [
                "Rodríguez", "González", "Fernández", "Pérez", "Martínez", "García", "López", "Sosa", "Silva", "Suárez",
                "Núñez", "Pereira", "Méndez", "Cáceres", "Torres", "Olivera", "Álvarez", "Gómez", "Díaz", "Romero",
                "Acosta", "Benítez", "Cabrera", "Ramos", "Castro", "Viera", "Techera", "Píriz", "Dos Santos", "De León",
                "Sánchez", "Hernández", "Da Silva", "De los Santos", "Ferreira", "Correa", "Moreira", "Machado", "Cardozo", "Morales",
                "Ramírez", "Muñoz", "Vázquez", "Ruiz", "Medina", "Gutiérrez", "Rocha", "Varela", "Lima", "Costa",
                "Godín", "Giménez", "Araújo", "Bentancur", "Valverde", "Ugarte", "Arrascaeta", "Pellistri", "Ojeda", "Vecino",
                "Torreira", "Stuani", "Cavani", "Forlán", "Recoba", "Lugano", "Muslera", "Rochet", "Coates", "Bueno",
                "Martinicorena", "Laxalt", "Lodeiro", "Arambarri", "Nández", "Sanabria", "Lemos", "Rossi", "Ferrari", "Piquerez",
                "Pintos", "Mieres", "Larrosa", "Bravo", "Rivero", "Delgado", "Peña", "Duarte", "Barrios", "Cabral",
                "Quintana", "Montero", "Borges", "Fagúndez", "Saldivia", "Rey", "Navarro", "Vega", "Luzardo", "Pacheco"
            ]),

        [Country.Holland] = new(
            [
                "Daan", "Sem", "Lucas", "Levi", "Finn", "Milan", "Bram", "Jesse", "Thijs", "Luuk",
                "Ruben", "Stijn", "Tim", "Jasper", "Niels", "Koen", "Bas", "Joost", "Sander", "Wouter",
                "Frenkie", "Matthijs", "Virgil", "Memphis", "Cody", "Denzel", "Xavi", "Jurriën", "Teun", "Wout",
                "Donyell", "Arjen", "Robin", "Wesley", "Dirk", "Rafael", "Klaas", "Jan", "Pieter", "Kees",
                "Marten", "Stefan", "Jeroen", "Ryan", "Joël", "Quinten", "Micky", "Lutsharel", "Nathan", "Steven",
                "Noah", "Liam", "Luca", "Mees", "Sven", "Lars", "Jens", "Gijs", "Hidde", "Jelle",
                "Joep", "Jip", "Pim", "Roel", "Rick", "Mark", "Dennis", "Patrick", "Edwin", "Ronald",
                "Frank", "Marco", "Ruud", "Johan", "Clarence", "Edgar", "Giovanni", "Phillip", "Kevin", "Mike",
                "Nick", "Max", "Tom", "Tijs", "Thom", "Bart", "Daley", "Davy", "Ibrahim", "Mohamed",
                "Hakim", "Noussair", "Sofyan", "Oussama", "Zakaria", "Anwar", "Ilias", "Bilal", "Hamza", "Ayoub",
                "Yassin", "Karim", "Mimoun", "Nordin", "Mounir", "Anass", "Achraf", "Romano", "Justin", "Jordan",
                "Brian", "Jeremain", "Georginio", "Quincy", "Jairo", "Eljero", "Kenneth", "Calvin", "Jetro", "Tyrell",
                "Jurrien", "Jorrel", "Jerdy", "Devyne", "Crysencio", "Jayden", "Mitchel", "Bobby", "Owen", "Jorrit",
                "Hans", "Henk", "Willem", "Wim", "Gerrit", "Cor", "Joris", "Maarten", "Floris", "Freek",
                "Siem", "Tygo", "Mats", "Thomas", "Julian", "Sepp", "Hugo", "Jeffrey", "Erik", "Arnaut",
                "Kenny", "Tonny", "Youri", "Danny", "Ricardo", "Rodney", "Roy", "Royston", "Nigel", "Gregory",
                "Urby", "Riechedly", "Jearl", "Leroy", "Ezechiel", "Lerin", "Elayis", "Wilfried", "Emanuel", "Vincent",
                "Bert", "Gert", "Ton", "Sjoerd", "Sietse", "Wiebe", "Ties", "Ivo", "Tjeerd", "Jochem",
                "Remco", "Ralf", "Rutger", "Michiel", "Laurens", "Reinier", "Olivier", "Sebastiaan", "Pepijn", "Teije",
                "Rens", "Kjell", "Jurgen", "Marcel", "Arnold", "Martijn", "Mathijs", "Dean", "Tahith", "Quilindschy",
                "Dani", "Etienne", "Lamare", "Tyronne", "Shurandy", "Javairô", "Mitchell", "Sergiño", "Juninho", "Tijjani",
                "Ian", "Kian", "Bryan", "Myron", "Million", "Ki-Jana", "Jeremie", "Noa", "Isaac", "Elias",
                "Adam", "Yusuf", "Ismail", "Mohammed", "Younes", "Anouar", "Jaap", "Frits", "Piet", "Kick",
                "Dick", "Rinus", "Arie", "Coen", "Jelte", "Tobias", "Stan", "Lasse", "Dex", "Boaz",
                "Melle", "Benjamin", "Morris", "Fedde", "Silvano", "Sydney", "Vurnon", "Lorenzo", "Jordy", "Jody"
            ],
            [
                "de Jong", "Jansen", "de Vries", "van den Berg", "van Dijk", "Bakker", "Janssen", "Visser", "Smit", "Meijer",
                "de Boer", "Mulder", "de Groot", "Bos", "Vos", "Peters", "Hendriks", "van Leeuwen", "Dekker", "Brouwer",
                "de Wit", "Dijkstra", "Smits", "de Graaf", "van der Meer", "van der Linden", "Kok", "Jacobs", "de Haan", "Vermeulen",
                "van den Heuvel", "van der Veen", "van den Broek", "de Bruijn", "de Bruin", "van der Heijden", "Schouten", "van Beek", "Willems", "van Vliet",
                "van de Ven", "Hoekstra", "Maas", "Verhoeven", "Koster", "van Dam", "van der Wal", "Prins", "Blom", "Huisman",
                "Peeters", "de Jonge", "Kuipers", "van Veen", "Post", "Kuiper", "Veenstra", "Kramer", "van den Brink", "Scholten",
                "van Wijk", "Postma", "Martens", "Vink", "de Ruiter", "Timmermans", "Groen", "Gerritsen", "Jonker", "van Loon",
                "Boer", "van der Velde", "Willemsen", "Smeets", "de Lange", "de Vos", "Bosch", "van Dongen", "Schipper", "de Koning",
                "van der Laan", "Koning", "van der Velden", "Driessen", "van Doorn", "Hermans", "Evers", "van den Bosch", "van der Meulen", "Hofman",
                "Bosman", "Wolters", "Sluiter", "Sneijder", "Kluivert", "Seedorf", "Davids", "Gullit", "Rijkaard", "Bergkamp"
            ]),

        [Country.Portugal] = new(
            [
                "João", "Rúben", "Bernardo", "Bruno", "Diogo", "Rafael", "Gonçalo", "Pedro", "Tiago", "Nuno",
                "Ricardo", "Rui", "André", "Francisco", "Miguel", "Duarte", "Tomás", "Martim", "Rodrigo", "Vítor",
                "Cristiano", "José", "António", "Manuel", "Luís", "Carlos", "Paulo", "Fernando", "Hugo", "Hélder",
                "Sérgio", "Fábio", "Renato", "William", "Danilo", "Nélson", "Raphael", "Otávio", "Matheus", "Joaquim",
                "Henrique", "Simão", "Ivo", "Daniel", "Samuel", "Leonardo", "Afonso", "Guilherme", "Dinis", "Filipe",
                "Abel", "Adriano", "Adelino", "Agostinho", "Alberto", "Alexandre", "Álvaro", "Américo", "Amílcar", "Anderson",
                "Ângelo", "Aníbal", "Armando", "Artur", "Augusto", "Baltasar", "Benjamim", "Bráulio", "Caetano", "Cédric",
                "Celso", "César", "Cláudio", "Cristóvão", "David", "Domingos", "Edgar", "Eduardo", "Edmundo", "Elias",
                "Emanuel", "Emílio", "Eurico", "Fausto", "Feliciano", "Félix", "Fernão", "Flávio", "Frederico", "Gabriel",
                "Gaspar", "Gelson", "Gil", "Gilberto", "Gustavo", "Hélio", "Horácio", "Humberto", "Igor", "Inácio",
                "Isaac", "Jaime", "Jardel", "Jerónimo", "Joel", "Jorge", "Josué", "Júlio", "Leandro", "Lourenço",
                "Lucas", "Marcelo", "Marco", "Mário", "Mateus", "Mauro", "Moisés", "Nicolau", "Norberto", "Octávio",
                "Orlando", "Óscar", "Patrício", "Raul", "Reinaldo", "Roberto", "Rolando", "Romeu", "Rómulo", "Salvador",
                "Sandro", "Sebastião", "Serafim", "Silvestre", "Sílvio", "Telmo", "Teodoro", "Tomé", "Valter", "Vasco",
                "Vicente", "Virgílio", "Wilson", "Xavier", "Yuri", "Mamadu", "Ansumane", "Aliu", "Braima", "Bubacar",
                "Edmilson", "Adrien", "Bernardino", "Bento", "Camilo", "Cândido", "Casimiro", "Constantino", "Custódio", "Damião",
                "Delfim", "Diamantino", "Dimas", "Ernesto", "Estêvão", "Eusébio", "Evaristo", "Fabrício", "Florentino", "Gervásio",
                "Gilson", "Hernâni", "Ilídio", "Isaías", "Ismael", "Jacinto", "Januário", "Juvenal", "Leonel", "Lino",
                "Lúcio", "Luciano", "Marcos", "Mariano", "Matias", "Maurício", "Micael", "Nataniel", "Olívio", "Paulino",
                "Quintino", "Rogério", "Sabino", "Saúl", "Severino", "Tobias", "Ulisses", "Valentim", "Wagner", "Wellington",
                "Zacarias", "Santiago", "Enzo", "Kevin", "Iuri", "Jordão", "Belmiro", "Wesley", "Nathan", "Bryan",
                "Dany", "Mickael", "Steven", "Jonathan", "Christopher", "Yannick", "Kelvin", "Thierry", "Edson", "Ronaldo",
                "Romário", "Anthony", "Adalberto", "Albano", "Alcides", "Alfredo", "Alípio", "Amândio", "Anselmo", "Antero",
                "Aurélio", "Avelino", "Basílio", "Celestino", "Cipriano", "Clemente", "Dário", "Délio", "Dionísio", "Egídio",
                "Elísio", "Eugénio", "Ezequiel", "Fabiano", "Felisberto", "Germano", "Gualter", "Heitor", "Hermínio", "Hilário"
            ],
            [
                "Silva", "Santos", "Ferreira", "Pereira", "Oliveira", "Costa", "Rodrigues", "Martins", "Jesus", "Sousa",
                "Fernandes", "Gonçalves", "Gomes", "Lopes", "Marques", "Alves", "Almeida", "Ribeiro", "Pinto", "Carvalho",
                "Teixeira", "Moreira", "Correia", "Mendes", "Nunes", "Soares", "Vieira", "Monteiro", "Cardoso", "Rocha",
                "Araújo", "Barbosa", "Barros", "Batista", "Borges", "Brito", "Campos", "Cunha", "Cruz", "Dias",
                "Domingues", "Duarte", "Faria", "Figueiredo", "Fonseca", "Freitas", "Garcia", "Henriques", "Leite", "Lima",
                "Lourenço", "Loureiro", "Machado", "Magalhães", "Matos", "Medeiros", "Melo", "Miranda", "Morais", "Moura",
                "Neves", "Nogueira", "Paiva", "Pacheco", "Patrício", "Pires", "Ramos", "Reis", "Sá", "Salgado",
                "Sampaio", "Simões", "Tavares", "Valente", "Vaz", "Veloso", "Coelho", "Antunes", "Azevedo", "Bastos",
                "Cabral", "Caldeira", "Castro", "Coutinho", "Esteves", "Fialho", "Guerreiro", "Leal", "Macedo", "Maia",
                "Neto", "Paixão", "Quaresma", "Rebelo", "Serrano", "Seixas", "Trindade", "Varela", "Vasconcelos", "Xavier"
            ]),

        [Country.Belgium] = new(
            [
                "Kevin", "Romelu", "Thibaut", "Eden", "Thorgan", "Axel", "Youri", "Leandro", "Jérémy", "Dries",
                "Toby", "Jan", "Thomas", "Yannick", "Timothy", "Arthur", "Charles", "Loïs", "Amadou", "Zeno",
                "Orel", "Koen", "Simon", "Maxime", "Michy", "Divock", "Marouane", "Nacer", "Christian", "Steven",
                "Hans", "Bart", "Wout", "Jens", "Pieter", "Lukas", "Noah", "Louis", "Victor", "Jules",
                "Mathis", "Senne", "Lander", "Arne", "Brecht", "Gilles", "Kobe", "Jef", "Hugo", "Robbe",
                "Aaron", "Alexander", "Anton", "Bram", "Dieter", "Dirk", "Elias", "Emiel", "Floris", "Gert",
                "Glenn", "Gunter", "Jasper", "Jelle", "Jeroen", "Jonas", "Joris", "Kasper", "Laurens", "Lars",
                "Lennert", "Maarten", "Matthias", "Michiel", "Nick", "Niels", "Olivier", "Rik", "Ruben", "Sander",
                "Siebe", "Stef", "Stijn", "Sven", "Tibo", "Tom", "Tuur", "Vincent", "Ward", "Wannes",
                "Warre", "Xander", "Kenneth", "Davy", "Wesley", "Sammy", "Jordy", "Brent", "Dante", "Ferre",
                "Finn", "Mats", "Milan", "Nathan", "Rune", "Seppe", "Stan", "Viktor", "Jarne", "Lenn",
                "Matisse", "Hannes", "Joran", "Kjell", "Thijs", "Wim", "Geert", "Filip", "Peter", "Marc",
                "Luc", "Erwin", "Gerrit", "Frank", "Alexis", "Antoine", "Benjamin", "Bastien", "Cédric", "Clément",
                "Damien", "Denis", "Dorian", "Emmanuel", "Étienne", "Florian", "François", "Frédéric", "Gaëtan", "Guillaume",
                "Hervé", "Jean", "Jérôme", "Julien", "Laurent", "Loïc", "Lucas", "Marius", "Mathieu", "Nicolas",
                "Pierre", "Quentin", "Raphaël", "Rémi", "Romain", "Sébastien", "Théo", "Tristan", "Valentin", "Yohan",
                "Benoît", "Grégory", "Jonathan", "Ludovic", "Philippe", "Sacha", "Timothée", "Adrien", "Alexandre", "Anthony",
                "Aurélien", "Baptiste", "Corentin", "Cyril", "Enzo", "Jordan", "Killian", "Maxence", "Noé", "Thibault",
                "Thierry", "Xavier", "Yannis", "Mehdi", "Nabil", "Ilias", "Ilyes", "Hamza", "Yassine", "Bilal",
                "Zakaria", "Anass", "Ayoub", "Ismaël", "Mohamed", "Karim", "Sofiane", "Rayan", "Adnan", "Selim",
                "Youssef", "Hakim", "Sami", "Nordin", "Walid", "Samir", "Chancel", "Landry", "Chris", "Dedryck",
                "Mike", "Joachim", "Junior", "Merveille", "Elton", "Malick", "Ibrahima", "Moussa", "Mamadou", "Ousmane",
                "Romeo", "Albert", "Arnaud", "Silvio", "Matteo", "Fabio", "Luca", "Mario", "Gianni", "Vito",
                "Dario", "Marco", "Mustafa", "Emre", "Burak", "Onur", "Mehmet", "Dennis", "Aster", "Jason",
                "Yari", "Mandela", "Hendrik", "Jorne", "Lowie", "Vic", "Mauro", "Nolan", "Ibe", "Joppe"
            ],
            [
                "Peeters", "Janssens", "Maes", "Jacobs", "Mertens", "Willems", "Claes", "Goossens", "Wouters", "De Smet",
                "Dubois", "Lambert", "Dupont", "Hermans", "Aerts", "Martens", "Michiels", "Pauwels", "Desmet", "De Clercq",
                "Leroy", "Vermeulen", "Van Damme", "Simon", "Lemaire", "Declercq", "Verhoeven", "De Backer", "Coppens", "Segers",
                "Van den Berghe", "Van de Velde", "De Wilde", "De Bruyne", "De Vos", "De Meyer", "Van Hecke", "Van Acker", "De Cock", "Van Dyck",
                "De Ketelaere", "Vandenberghe", "Verstraete", "Vermeersch", "Lemmens", "Smets", "Stevens", "Thys", "Dumont", "Lejeune",
                "Renard", "Leclercq", "Mathieu", "Laurent", "Denis", "Fontaine", "Collard", "François", "Gérard", "Charlier",
                "Henry", "Martin", "Lambrechts", "Baert", "Hendrickx", "Cools", "Verbeke", "Bogaert", "Vandenbroucke", "Verschueren",
                "Geerts", "Wuyts", "Raes", "Verlinden", "Nys", "Bertrand", "Delvaux", "Denayer", "Goffin", "Gillet",
                "Hubert", "Jacquet", "Lecomte", "Massart", "Noël", "Renson", "Thiry", "Wauters", "Vertonghen", "Vanaken",
                "Theate", "Castagne", "Tielemans", "Lukaku", "Kabasele", "Kompany", "Mbemba", "Doku", "Openda", "Lokonga"
            ]),

        [Country.Croatia] = new(
            [
                "Luka", "Ivan", "Mateo", "Marko", "Josip", "Ante", "Domagoj", "Dejan", "Andrej", "Nikola",
                "Mario", "Marcelo", "Lovro", "Joško", "Borna", "Bruno", "Dominik", "Petar", "Filip", "Tomislav",
                "Davor", "Zvonimir", "Igor", "Darijo", "Vedran", "Šime", "Duje", "Mislav", "Martin", "Kristijan",
                "Stipe", "Dario", "Toni", "Niko", "Leon", "Karlo", "Roko", "Fran", "Jakov", "Matej",
                "Antonio", "Krunoslav", "Robert", "Hrvoje", "Zoran", "Goran", "Damir", "Vladimir", "Danijel", "Nenad",
                "Adrian", "Alen", "Aleksandar", "Anđelo", "Antun", "Bartol", "Benjamin", "Berislav", "Bojan", "Boris",
                "Božidar", "Branimir", "Branko", "Damjan", "Darko", "Davorin", "Denis", "Dino", "Dražen", "Dragan",
                "Dubravko", "Duško", "Edi", "Elvis", "Emanuel", "Eugen", "Fabijan", "Franjo", "Gabrijel", "Gordan",
                "Ilija", "Ivica", "Ivo", "Ivano", "Ivor", "Jakša", "Jerko", "Jure", "Juraj", "Jurica",
                "Krešimir", "Leo", "Ljubomir", "Lukas", "Marin", "Marijan", "Marijo", "Mate", "Matija", "Matko",
                "Mihael", "Miroslav", "Mirko", "Mladen", "Neven", "Nino", "Oliver", "Patrik", "Pero", "Predrag",
                "Rajko", "Ranko", "Renato", "Romano", "Saša", "Sandro", "Silvio", "Siniša", "Slaven", "Srećko",
                "Stanko", "Stjepan", "Sven", "Tin", "Tino", "Tomo", "Tonći", "Toma", "Valentino", "Vatroslav",
                "Vice", "Vinko", "Viktor", "Vjekoslav", "Zdravko", "Zlatko", "Željko", "Živko", "Jozo", "Anton",
                "Bernard", "Dalibor", "Ervin", "Frane", "Lovre", "Marino", "Mato", "Mihovil", "Nikša", "Ozren",
                "Paško", "Pavao", "Radoslav", "Sebastijan", "Stipo", "Teo", "Tihomir", "Velimir", "Vlatko", "Zvonko",
                "Želimir", "Noa", "Gabriel", "Jan", "Vito", "Rafael", "Mauro", "Nikolas", "Erik", "David",
                "Liam", "Bartul", "Boško", "Bože", "Dinko", "Emil", "Eduard", "Elio", "Ferdo", "Florijan",
                "Josko", "Kazimir", "Lucijan", "Ljudevit", "Marjan", "Marcel", "Maks", "Maksim", "Milan", "Miljenko",
                "Nediljko", "Nikica", "Oskar", "Pino", "Rino", "Roberto", "Rok", "Rudolf", "Sanjin", "Slavko",
                "Stipan", "Tadija", "Tvrtko", "Vid", "Zrinko", "Žarko", "Eldin", "Amir", "Armin", "Haris",
                "Senad", "Edin", "Kristian", "Andro", "Dorian", "Lukša", "Antonijo", "Brane", "Dane", "Hrvoslav",
                "Jadran", "Lovorko", "Nikolaj", "Ratko", "Silvije", "Tomica", "Valentin", "Zdenko", "Andrija", "Augustin",
                "Dragutin", "Ernest", "Franko", "Ignacije", "Jasenko", "Kruno", "Lino", "Lorenco", "Mak", "Matias",
                "Mile", "Milivoj", "Miro", "Ninoslav", "Pavle", "Sebastian", "Stanislav", "Šimun", "Tonko", "Vladislav"
            ],
            [
                "Horvat", "Kovačević", "Babić", "Marić", "Jurić", "Novak", "Kovačić", "Knežević", "Vuković", "Marković",
                "Petrović", "Matić", "Tomić", "Pavlović", "Perić", "Božić", "Blažević", "Grgić", "Pavić", "Radić",
                "Perković", "Šarić", "Lovrić", "Vidović", "Kos", "Bošnjak", "Brkić", "Rukavina", "Vrdoljak", "Barišić",
                "Jukić", "Klarić", "Lučić", "Mandić", "Matković", "Mikulić", "Nikolić", "Pejić", "Petković", "Popović",
                "Rajić", "Šimić", "Stipić", "Tadić", "Vlašić", "Vukić", "Zorić", "Bašić", "Begić", "Bilić",
                "Bokšić", "Brozović", "Budimir", "Čorluka", "Ćorić", "Gvardiol", "Erceg", "Filipović", "Galić", "Grgurić",
                "Ivanković", "Ivanović", "Ivančić", "Jelić", "Josipović", "Jozić", "Kalinić", "Kramarić", "Lovren", "Majer",
                "Mamić", "Mandžukić", "Marušić", "Mihaljević", "Milić", "Modrić", "Oršić", "Pašalić", "Petrić", "Pjaca",
                "Rakitić", "Rebić", "Sučić", "Šutalo", "Vida", "Livaković", "Stanišić", "Tolić", "Topić", "Vučković",
                "Zelić", "Žužul", "Jakić", "Kovač", "Lukić", "Ćosić", "Herceg", "Kolar", "Kralj", "Pranjić"
            ]),

        [Country.Colombia] = new(
            [
                "James", "Radamel", "Juan", "Luis", "Carlos", "David", "Davinson", "Yerry", "Jhon", "Duván",
                "Rafael", "Wilmar", "Mateus", "Jefferson", "Cristian", "Andrés", "Santiago", "Camilo", "Sebastián", "Daniel",
                "Jorge", "Óscar", "Freddy", "Faustino", "Yimmi", "Johan", "Kevin", "Brayan", "Stiven", "Richard",
                "Edwin", "Frank", "Miguel", "Alejandro", "Diego", "Felipe", "Jaminton", "Déiver", "Yáser", "Gustavo",
                "Hernán", "Iván", "Fabián", "Julián", "Álvaro", "Alexis", "Nicolás", "Mauricio", "René", "Teófilo",
                "Abel", "Adrián", "Aldair", "Alfredo", "Anderson", "Ángel", "Arley", "Armando", "Bayron", "Bernardo",
                "Breiner", "Carmelo", "César", "Cristhian", "Dairon", "Darwin", "Dorlan", "Dumar", "Edwar", "Eder",
                "Édinson", "Elkin", "Éider", "Emerson", "Enrique", "Esteban", "Estiven", "Ever", "Fernando", "Francisco",
                "Fredy", "Gabriel", "Germán", "Giovanni", "Harold", "Héctor", "Hugo", "Humberto", "Isaac", "Jaider",
                "Jair", "Jairo", "Jarlan", "Javier", "Jeison", "Jhojan", "Jhonatan", "Jonathan", "Jorman", "Jhonier",
                "José", "Joaquín", "Kelvin", "Leonardo", "Leider", "Manuel", "Marlon", "Marcos", "Mario", "Martín",
                "Matías", "Maicol", "Michael", "Mayer", "Néider", "Nelson", "Omar", "Orlando", "Pablo", "Pedro",
                "Ricardo", "Roberto", "Rodrigo", "Roger", "Ronaldo", "Samuel", "Sergio", "Steven", "Tomás", "Víctor",
                "Wílder", "William", "Wilson", "Yeison", "Yerson", "Yeferson", "Yairo", "Yohan", "Elías", "Emanuel",
                "Faber", "Farid", "Fáider", "Geovanny", "Gonzalo", "Guillermo", "Harrison", "Jaime", "Jesús", "Kener",
                "Larry", "Lucas", "Leonel", "Luciano", "Milton", "Nilson", "Ramiro", "Raúl", "Reinaldo", "Rigoberto",
                "Rubén", "Salomón", "Sneyder", "Vladimir", "Walmer", "Yilmar", "Alexander", "Brahian", "Didier", "Dilan",
                "Edgar", "Eduardo", "Efraín", "Ernesto", "Fabio", "Gerardo", "Gilberto", "Hernando", "Ismael", "Jefry",
                "Jherson", "Kennedy", "León", "Lorenzo", "Marino", "Mateo", "Maximiliano", "Norberto", "Octavio", "Ramón",
                "Rolando", "Ronald", "Simón", "Walter", "Wílmer", "Yesid", "Yair", "Andrey", "Arnold", "Alberto",
                "Alonso", "Antonio", "Arturo", "Ayron", "Baldomero", "Brandon", "Dairo", "Danilo", "Deivy", "Eduar",
                "Elver", "Emiro", "Ferney", "Fredys", "Hamilton", "Helmer", "Heriberto", "Jader", "Jámison", "Jeyson",
                "Leiner", "Libardo", "Luber", "Marcelino", "Óiver", "Ómar", "Sammy", "Tréllez", "Wálter", "Weimar",
                "Yeiler", "Aníbal", "Ariel", "Cristóbal", "Domingo", "Elmer", "Gerson", "Jhonny", "Jimmy", "Jordan",
                "Leandro", "Leonidas", "Neyder", "Néstor", "Patricio", "Robinson", "Royner", "Santos", "Stefan", "Tobías"
            ],
            [
                "Rodríguez", "Gómez", "González", "Martínez", "García", "López", "Hernández", "Sánchez", "Ramírez", "Pérez",
                "Díaz", "Muñoz", "Rojas", "Moreno", "Jiménez", "Vargas", "Castro", "Gutiérrez", "Ortiz", "Torres",
                "Valencia", "Mosquera", "Cuadrado", "Córdoba", "Zapata", "Murillo", "Arias", "Ospina", "Mina", "Palacios",
                "Acosta", "Aguilar", "Álvarez", "Arango", "Asprilla", "Balanta", "Banguera", "Barrios", "Bedoya", "Borja",
                "Cabezas", "Caicedo", "Cardona", "Carrascal", "Castaño", "Castillo", "Cifuentes", "Cuesta", "Cuéllar", "Durán",
                "Escobar", "Estupiñán", "Fuentes", "Galeano", "Giraldo", "Guarín", "Henao", "Hinestroza", "Ibargüen", "Lerma",
                "Londoño", "Lozano", "Lucumí", "Machado", "Medina", "Mejía", "Mena", "Montero", "Montoya", "Navarro",
                "Orozco", "Osorio", "Parra", "Perea", "Quintero", "Quiñones", "Restrepo", "Renterías", "Riascos", "Rincón",
                "Salazar", "Sierra", "Suárez", "Uribe", "Valoyes", "Vásquez", "Velásquez", "Villa", "Zuluaga", "Ramos",
                "Arboleda", "Angulo", "Borré", "Chará", "Lasso", "Herrera", "Correa", "Ruiz", "Agudelo", "Ochoa"
            ]),

        [Country.Mexico] = new(
            [
                "Javier", "Andrés", "Rafael", "Héctor", "Raúl", "Hirving", "Carlos", "Jesús", "Guillermo", "Edson",
                "Luis", "Jorge", "Diego", "Alexis", "Orbelín", "Santiago", "César", "Uriel", "Gerardo", "Erick",
                "José", "Juan", "Miguel", "Alejandro", "Francisco", "Fernando", "Ricardo", "Roberto", "Eduardo", "Óscar",
                "Cuauhtémoc", "Jonathan", "Giovani", "Marco", "Julián", "Israel", "Gilberto", "Emilio", "Mateo", "Sebastián",
                "Rodrigo", "Iván", "Hugo", "Omar", "Ángel", "Kevin", "Johan", "Néstor", "Arturo", "Víctor",
                "Abraham", "Adrián", "Agustín", "Alan", "Alberto", "Alfonso", "Alfredo", "Alonso", "Antonio", "Armando",
                "Benjamín", "Brian", "Cristian", "Daniel", "David", "Efraín", "Elías", "Emiliano", "Emmanuel", "Enrique",
                "Ernesto", "Esteban", "Fabián", "Federico", "Felipe", "Fidel", "Gabriel", "Germán", "Gonzalo", "Gustavo",
                "Heriberto", "Horacio", "Humberto", "Ignacio", "Isaac", "Isaías", "Jaime", "Jair", "Jared", "Joaquín",
                "Jordan", "Josué", "Julio", "Leonardo", "Lorenzo", "Lucas", "Manuel", "Marcelo", "Marcos", "Mario",
                "Martín", "Mauricio", "Maximiliano", "Moisés", "Octavio", "Orlando", "Oswaldo", "Pablo", "Patricio", "Pedro",
                "Ramón", "Ramiro", "Raymundo", "Rogelio", "Rubén", "Salvador", "Samuel", "Saúl", "Sergio", "Tomás",
                "Ulises", "Vicente", "Alexander", "Aldo", "Álvaro", "Aarón", "Axel", "Bernardo", "Brayan", "Brandon",
                "Bruno", "Damián", "Dante", "Edgar", "Edgardo", "Eder", "Efrén", "Elio", "Ezequiel", "Fausto",
                "Gael", "Hiram", "Leonel", "Misael", "Nicolás", "Obed", "Paul", "Rigoberto", "Rodolfo", "Rolando",
                "Ronaldo", "Teodoro", "Tonatiuh", "Yael", "Benito", "Camilo", "Claudio", "Cristóbal", "Dionisio", "Domingo",
                "Eugenio", "Everardo", "Félix", "Genaro", "Gregorio", "Ismael", "Jerónimo", "Jonás", "Leobardo", "Leopoldo",
                "Lucio", "Luciano", "Marcial", "Mauro", "Noé", "Norberto", "Pascual", "Reynaldo", "Román", "Santos",
                "Simón", "Tadeo", "Valentín", "Gibrán", "Uziel", "Ozziel", "Henry", "Marcel", "Abel", "Adán",
                "Aurelio", "Baltazar", "Fermín", "Irving", "Jahir", "Joel", "Leandro", "Mariano", "Renato", "Said",
                "Silvestre", "Tobías", "Hernán", "Arath", "Ansel", "Jordi", "Marcelino", "Faustino", "Gerónimo", "Juvenal",
                "Nahum", "Severo", "Wilfrido", "Zeus", "Bryan", "Christopher", "Erik", "Jairo", "Owen", "Abelardo",
                "Adalberto", "Amado", "Anselmo", "Bernabé", "Celso", "Ciro", "Edmundo", "Eliseo", "Erasmo", "Esaú",
                "Eusebio", "Fabricio", "Florencio", "Gaspar", "Hilario", "Homero", "Isidro", "Jacinto", "Juventino", "Lázaro",
                "Matías", "Otoniel", "Porfirio", "Rosendo", "Teófilo", "Ubaldo", "Vidal", "Zacarías", "Iker", "Thiago"
            ],
            [
                "Hernández", "García", "Martínez", "López", "González", "Rodríguez", "Pérez", "Sánchez", "Ramírez", "Flores",
                "Gómez", "Díaz", "Cruz", "Morales", "Reyes", "Torres", "Gutiérrez", "Ruiz", "Mendoza", "Aguilar",
                "Ortiz", "Castillo", "Moreno", "Jiménez", "Vázquez", "Romero", "Álvarez", "Herrera", "Medina", "Chávez",
                "Acosta", "Aguirre", "Alvarado", "Ávila", "Barrera", "Bautista", "Benítez", "Cabrera", "Calderón", "Camacho",
                "Campos", "Cárdenas", "Carrillo", "Castro", "Cervantes", "Contreras", "Córdova", "Corona", "Delgado", "Domínguez",
                "Espinoza", "Estrada", "Fuentes", "Gallardo", "Gallegos", "Guerrero", "Guzmán", "Ibarra", "Juárez", "Lara",
                "León", "Luna", "Maldonado", "Márquez", "Mejía", "Meza", "Miranda", "Molina", "Montes", "Navarro",
                "Núñez", "Orozco", "Ortega", "Pacheco", "Padilla", "Peña", "Ramos", "Ríos", "Rivera", "Robles",
                "Rojas", "Rosales", "Salazar", "Salinas", "Sandoval", "Santiago", "Silva", "Solís", "Soto", "Suárez",
                "Trejo", "Valdez", "Valenzuela", "Vargas", "Vega", "Velázquez", "Villa", "Zamora", "Zavala", "Ochoa"
            ]),

        [Country.Nigeria] = new(
            [
                "Victor", "Ahmed", "Alex", "Samuel", "Kelechi", "Wilfred", "Ademola", "Moses", "Odion", "Sadiq",
                "Taiwo", "William", "Calvin", "Frank", "Joe", "Kenneth", "Paul", "Chidera", "Emmanuel", "Nnamdi",
                "Chukwuemeka", "Obinna", "Ikechukwu", "Chinedu", "Uchenna", "Tochukwu", "Oluwaseun", "Ayodele", "Babatunde", "Olumide",
                "Segun", "Tunde", "Femi", "Kunle", "Yakubu", "Ibrahim", "Musa", "Abdullahi", "Sani", "Chima",
                "Austin", "Daniel", "John", "Peter", "Godwin", "Friday", "Sunday", "Efe", "Kalu", "Bright",
                "Chidi", "Chibuzor", "Chinonso", "Chukwudi", "Chijioke", "Chigozie", "Ebuka", "Emeka", "Ifeanyi", "Ikenna",
                "Jude", "Kingsley", "Nonso", "Obiora", "Okechukwu", "Onyekachi", "Uche", "Uchechukwu", "Ugochukwu", "Azubuike",
                "Chibueze", "Chukwuma", "Chimezie", "Chinemerem", "Chiemeka", "Somtochukwu", "Ekene", "Ejike", "Nnaemeka", "Kenechukwu",
                "Izuchukwu", "Ndubuisi", "Nwabueze", "Anayo", "Arinze", "Ebube", "Echezona", "Ugonna", "Chukwunonso", "Tobenna",
                "Ikechi", "Chijindu", "Onyeka", "Adebayo", "Adewale", "Adeniyi", "Adekunle", "Adeleke", "Akinwale", "Bolaji",
                "Gbenga", "Kayode", "Kehinde", "Olamide", "Oladapo", "Olajide", "Olalekan", "Olatunji", "Oluwafemi", "Oluwatobi",
                "Oluwadamilare", "Oluwaseyi", "Olusegun", "Rotimi", "Tobi", "Wale", "Yemi", "Dapo", "Bayo", "Seyi",
                "Lekan", "Jide", "Tijani", "Abiodun", "Akeem", "Ayobami", "Babajide", "Dayo", "Ebenezer", "Fisayo",
                "Gbolahan", "Idowu", "Kolawole", "Lanre", "Mayowa", "Muyiwa", "Niyi", "Oladimeji", "Olaniyi", "Olawale",
                "Opeyemi", "Rasheed", "Semiu", "Shola", "Tayo", "Tobiloba", "Wasiu", "Taofeek", "Kazeem", "Lukman",
                "Sodiq", "Saheed", "Ganiyu", "Ayodeji", "Oladipupo", "Olusola", "Abayomi", "Akinola", "Ayotunde", "Bamidele",
                "Folarin", "Olabode", "Adeshina", "Semi", "Ola", "Aliyu", "Bashir", "Sulaiman", "Umar", "Usman",
                "Haruna", "Garba", "Shehu", "Nura", "Kabiru", "Mustapha", "Abdulrahman", "Abubakar", "Isa", "Idris",
                "Jamilu", "Murtala", "Nasiru", "Rabiu", "Sanusi", "Yusuf", "Zakari", "Auwal", "Bala", "Danladi",
                "Ismaila", "Muhammed", "Salisu", "Abdulkadir", "Ahmad", "Tukur", "Hassan", "Jibril", "Mohammed", "Mukhtar",
                "Kabir", "Shuaibu", "Dahiru", "Gambo", "Zaidu", "Michael", "David", "Joseph", "James", "Stephen",
                "Anthony", "Augustine", "Benjamin", "Christian", "Christopher", "Collins", "Cyril", "Dennis", "Edwin", "Felix",
                "Francis", "Gabriel", "George", "Henry", "Isaac", "Jerome", "Joel", "Jonathan", "Joshua", "Kevin",
                "Lucky", "Matthew", "Monday", "Nelson", "Nathaniel", "Patrick", "Raphael", "Richard", "Robert", "Solomon",
                "Stanley", "Wisdom", "Innocent", "Promise", "Sylvester", "Simeon", "Philip", "Ambrose", "Bernard", "Clement"
            ],
            [
                "Okafor", "Okonkwo", "Adeyemi", "Ogunleye", "Eze", "Nwosu", "Okeke", "Obi", "Balogun", "Adebayo",
                "Okoro", "Nwachukwu", "Uzor", "Olawale", "Akinwale", "Bello", "Lawal", "Abubakar", "Mohammed", "Ibrahim",
                "Yusuf", "Chukwu", "Nnadi", "Ekong", "Ndidi", "Aribo", "Ajayi", "Onuachu", "Iheanacho", "Awoniyi",
                "Osimhen", "Lookman", "Chukwueze", "Iwobi", "Simon", "Ighalo", "Musa", "Troost-Ekong", "Omeruo", "Awaziem",
                "Aina", "Bassey", "Uzoho", "Okoye", "Nwabali", "Onyeka", "Moffi", "Sadiq", "Boniface", "Osayi-Samuel",
                "Ebuehi", "Osagie", "Omoregie", "Igiebor", "Ekpo", "Effiong", "Etim", "Okon", "Udoh", "Akpan",
                "Essien", "Edet", "Inyang", "Adeleke", "Adewale", "Adeniyi", "Afolabi", "Akinola", "Akande", "Alabi",
                "Fashola", "Ogunbiyi", "Oyedele", "Oyewole", "Ojo", "Olatunji", "Olaniyan", "Olayinka", "Oni", "Oladipo",
                "Owolabi", "Salami", "Shittu", "Sanni", "Taiwo", "Kehinde", "Idowu", "Adeoye", "Agbaje", "Anichebe",
                "Anyanwu", "Chukwuma", "Ezeh", "Ezeani", "Ibe", "Igwe", "Mbah", "Nwankwo", "Nwafor", "Nwoko"
            ]),

        [Country.Senegal] = new(
            [
                "Sadio", "Kalidou", "Idrissa", "Ismaïla", "Cheikhou", "Édouard", "Pape", "Bamba", "Abdou", "Nampalys",
                "Krépin", "Boulaye", "Famara", "Iliman", "Nicolas", "Moussa", "Mamadou", "Ousmane", "Abdoulaye", "Ibrahima",
                "Cheikh", "Lamine", "Alioune", "Modou", "Babacar", "Amadou", "Aliou", "Youssouf", "Khadim", "Mbaye",
                "Assane", "Malick", "Souleymane", "Demba", "Habib", "Seydou", "Saliou", "Omar", "Fodé", "Boubacar",
                "Djibril", "Samba", "Serigne", "Moustapha", "Pathé", "Mame", "Elhadji", "Arona", "Lassana", "Formose",
                "Alassane", "Aly", "Ablaye", "Abdourahmane", "Adama", "Alpha", "Amath", "Ansou", "Arfang", "Bacary",
                "Badou", "Bakary", "Balla", "Bassirou", "Biram", "Bouna", "Chérif", "Cheikhna", "Daouda", "Dame",
                "Dethié", "Diafra", "Diomansy", "Elimane", "Fallou", "Fadel", "Gana", "Gorgui", "Hamady", "Hamidou",
                "Ibou", "Insa", "Issa", "Kader", "Kéba", "Khalifa", "Khalilou", "Landing", "Lat", "Libasse",
                "Makhtar", "Malang", "Mamour", "Mansour", "Massamba", "Matar", "Médoune", "Moctar", "Mohamed", "Momar",
                "Ngagne", "Nouha", "Ndiaga", "Ngor", "Oumar", "Ousseynou", "Papiss", "Racine", "Rassoul", "Saër",
                "Salif", "Santy", "Sékou", "Seydina", "Sidy", "Tidiane", "Thierno", "Waly", "Yaya", "Youssou",
                "Seny", "Mory", "Mikayil", "Ilay", "Abdallah", "Ibrahim", "Dion", "Amara", "Arouna", "Ismail",
                "Abdoul", "Mamoudou", "Saïdou", "Yéro", "Ciré", "Tamsir", "Hamath", "Mountaga", "Diégane", "Latyr",
                "Djiby", "Mbagnick", "Mor", "Bara", "Birane", "Magatte", "Aziz", "Baye", "Gora", "Doudou",
                "Laye", "Lahad", "Mouhamed", "Iba", "Gallo", "Thione", "Mouhamadou", "Ababacar", "Talla", "Ansoumana",
                "Mamadi", "Sadibou", "Ismaël", "Jean", "Pierre", "Louis", "Joseph", "Michel", "Antoine", "Christophe",
                "François", "Philippe", "Henri", "Jacques", "Benjamin", "Bruno", "Cédric", "Ferdinand", "Frédéric", "Gilbert",
                "Grégoire", "Hervé", "Julien", "Lucien", "Marcel", "Mathieu", "Olivier", "Patrice", "Paul", "Pascal",
                "Raphaël", "Rémi", "Roger", "Romain", "Serge", "Simon", "Stéphane", "Thomas", "Victor", "Vincent",
                "Xavier", "Yann", "Gabriel", "Alfred", "Albert", "Alexandre", "Augustin", "Dominique", "Emmanuel", "Éric",
                "Étienne", "Félix", "Georges", "Gérard", "Ignace", "Jérôme", "Joël", "Laurent", "Léon", "Marc",
                "Martin", "Maurice", "Noël", "René", "Samuel", "Sylvain", "Ange", "Basile", "Bertrand", "Clément",
                "Denis", "Fabrice", "Florent", "Jules", "Yves", "Abass", "Baba", "Bocar", "Boubou", "Cheikhouna",
                "Hady", "Lansana", "Madické", "Sékouba", "Seyni", "Souleye", "Tafsir", "Abibou", "Bouba", "Maodo"
            ],
            [
                "Diop", "Ndiaye", "Fall", "Sarr", "Diallo", "Sow", "Gueye", "Faye", "Mbaye", "Diouf",
                "Cissé", "Ba", "Seck", "Kane", "Thiam", "Niang", "Ndoye", "Sy", "Dieng", "Mendy",
                "Koulibaly", "Gomis", "Badji", "Diatta", "Camara", "Touré", "Wagué", "Dia", "Mané", "Kouyaté",
                "Ndour", "Ndao", "Ndong", "Ndione", "Ngom", "Diagne", "Diakhaté", "Diarra", "Diaw", "Diédhiou",
                "Dione", "Dramé", "Fofana", "Goudiaby", "Kanté", "Konaté", "Lô", "Loum", "Ly", "Mbengue",
                "Mbodj", "Mboup", "Niakhaté", "Niasse", "Sall", "Samb", "Sané", "Sagna", "Sène", "Sidibé",
                "Sonko", "Sylla", "Tall", "Thiaw", "Thioune", "Wade", "Wane", "Badiane", "Bodian", "Coly",
                "Coulibaly", "Dabo", "Daffé", "Diaby", "Diack", "Diakhaby", "Diémé", "Dièye", "Faty", "Gassama",
                "Gning", "Kébé", "Konté", "Lopy", "Manga", "Mbacké", "Niane", "Sabaly", "Sakho", "Sambou",
                "Sangharé", "Seye", "Sima", "Sissoko", "Soumaré", "Tine", "Traoré", "Djité", "Bassène", "Ciss"
            ]),

        [Country.Japan] = new(
            [
                "Takumi", "Kaoru", "Daichi", "Wataru", "Takehiro", "Ritsu", "Junya", "Ayase", "Hiroki", "Yuto",
                "Shuichi", "Ko", "Kyogo", "Takefusa", "Ao", "Daizen", "Reo", "Hidemasa", "Kento", "Shogo",
                "Yuya", "Keisuke", "Shinji", "Maya", "Makoto", "Yasuhito", "Yoshinori", "Gaku", "Hidetoshi", "Shunsuke",
                "Atsuto", "Eiji", "Genki", "Gotoku", "Hotaru", "Koki", "Kazuki", "Ryota", "Sho", "Shota",
                "Taichi", "Takuma", "Tatsuya", "Yuki", "Haruto", "Sota", "Ren", "Riku", "Kaito", "Hayato",
                "Akira", "Akihiro", "Atsushi", "Daiki", "Daisuke", "Daigo", "Eita", "Fumiya", "Haruki", "Haruya",
                "Hiroshi", "Hiroto", "Hiroyuki", "Hidetaka", "Hideki", "Hikaru", "Hiroaki", "Hisashi", "Ikuma", "Issei",
                "Itsuki", "Jun", "Junichi", "Junki", "Junpei", "Kaisei", "Kazuya", "Kazuma", "Kazuyuki", "Keita",
                "Keito", "Ken", "Kengo", "Kenji", "Kenta", "Kenyu", "Kensuke", "Kosuke", "Koji", "Kota",
                "Kotaro", "Kyosuke", "Manabu", "Masaki", "Masato", "Masahiro", "Masashi", "Masaya", "Masataka", "Mao",
                "Minato", "Mitsuki", "Naoki", "Naoto", "Naomichi", "Nobuhiro", "Ryo", "Ryoma", "Ryosuke", "Ryuji",
                "Ryunosuke", "Ryuta", "Ryutaro", "Satoshi", "Seiya", "Shinnosuke", "Shintaro", "Shion", "Shu", "Shunta",
                "Shuto", "Shusuke", "Sora", "Soma", "Shoya", "Shuhei", "Shunya", "Shinya", "Shinpei", "Shoma",
                "So", "Sosuke", "Subaru", "Taisei", "Takashi", "Takeshi", "Taketo", "Takuya", "Takahiro", "Tomoya",
                "Tomoki", "Tomoaki", "Toshiki", "Toshiya", "Tsubasa", "Tsukasa", "Tatsuki", "Tatsuhiro", "Teruki", "Tetsuya",
                "Toru", "Yamato", "Yasuto", "Yoshiaki", "Yoshiki", "Yoshito", "Yosuke", "Yu", "Yudai", "Yuji",
                "Yuma", "Yusuke", "Yuta", "Yutaka", "Yuichi", "Yuhei", "Yuichiro", "Yukinari", "Yuito", "Kodai",
                "Kohei", "Kyohei", "Kai", "Kanta", "Keigo", "Koya", "Rikuto", "Ryuya", "Seiji", "Taiga",
                "Taishi", "Taisuke", "Takayuki", "Tadanari", "Teppei", "Tomohiro", "Yohei", "Yoshihiro", "Yasushi", "Toshihiro",
                "Keiya", "Koichi", "Kosei", "Kyoya", "Naoya", "Ryuho", "Taiki", "Taito", "Yukiya", "Akito",
                "Akinori", "Asahi", "Ayumu", "Daito", "Eisuke", "Go", "Gakuto", "Hirokazu", "Jiro", "Kakeru",
                "Keiji", "Kenshin", "Kenichi", "Kiyoshi", "Koshiro", "Mamoru", "Masahiko", "Masayuki", "Minoru", "Mitsuru",
                "Motoki", "Noriaki", "Norihiro", "Osamu", "Ryohei", "Ryuichi", "Saku", "Shigeru", "Shingo", "Shuji",
                "Shunki", "Takanori", "Takeru", "Tomokazu", "Toshio", "Tsuyoshi", "Yoshiro", "Yukio", "Yuga", "Yuzo",
                "Zen", "Akihiko", "Hayate", "Ichiro", "Isamu", "Kentaro", "Masaaki", "Rintaro", "Seigo", "Tadashi"
            ],
            [
                "Sato", "Suzuki", "Takahashi", "Tanaka", "Watanabe", "Ito", "Yamamoto", "Nakamura", "Kobayashi", "Kato",
                "Yoshida", "Yamada", "Sasaki", "Yamaguchi", "Matsumoto", "Inoue", "Kimura", "Hayashi", "Shimizu", "Yamazaki",
                "Mori", "Abe", "Ikeda", "Hashimoto", "Ishikawa", "Ogawa", "Endo", "Kamada", "Minamino", "Kubo",
                "Kondo", "Ishii", "Saito", "Maeda", "Fujita", "Okada", "Goto", "Hasegawa", "Murakami", "Ishida",
                "Sakamoto", "Aoki", "Fujii", "Nishimura", "Fukuda", "Ota", "Miura", "Fujiwara", "Okamoto", "Matsuda",
                "Nakagawa", "Nakano", "Harada", "Ono", "Tamura", "Takeuchi", "Kaneko", "Wada", "Nakayama", "Ishihara",
                "Morita", "Shibata", "Sakai", "Kudo", "Yokoyama", "Miyazaki", "Miyamoto", "Uchida", "Takagi", "Ando",
                "Taniguchi", "Maruyama", "Imai", "Takada", "Fujimoto", "Takeda", "Murata", "Ueno", "Sugiyama", "Masuda",
                "Sugawara", "Hirano", "Otsuka", "Chiba", "Kubota", "Matsui", "Iwasaki", "Sakurai", "Kinoshita", "Noguchi",
                "Matsuo", "Nomura", "Kikuchi", "Sano", "Onishi", "Sugimoto", "Arai", "Hamada", "Ichikawa", "Furukawa"
            ]),

        [Country.Denmark] = new(
            [
                "Christian", "Kasper", "Simon", "Pierre-Emile", "Andreas", "Joakim", "Thomas", "Mikkel", "Rasmus", "Jonas",
                "Yussuf", "Martin", "Daniel", "Mathias", "Jesper", "Morten", "Anders", "Jens", "Lars", "Henrik",
                "Peter", "Michael", "Nicolai", "Frederik", "Mads", "Jannik", "Victor", "Oliver", "Emil", "William",
                "Magnus", "Lucas", "Noah", "Malthe", "Gustav", "Alfred", "Carl", "Elias", "Sebastian", "Kristoffer",
                "Philip", "Jacob", "Casper", "Søren", "Nikolaj", "Patrick", "Brian", "Allan", "Kim", "Rune",
                "Aksel", "Albert", "Alexander", "Anton", "Arthur", "Asger", "Benjamin", "Bjarke", "Bo", "Christoffer",
                "Claus", "Dennis", "Erik", "Esben", "Felix", "Finn", "Flemming", "Hans", "Hjalte", "Ivan",
                "Jakob", "Jan", "Jeppe", "Johan", "Johannes", "Jonathan", "Jon", "Jørgen", "Kenneth", "Kristian",
                "Laurits", "Lasse", "Leo", "Linus", "Lukas", "Max", "Nicklas", "Niels", "Ole", "Oskar",
                "Otto", "Palle", "Per", "Poul", "Preben", "René", "Silas", "Steffen", "Stefan", "Sune",
                "Svend", "Theo", "Thor", "Tobias", "Troels", "Ulrik", "Valdemar", "Villads", "Vincent", "Aske",
                "August", "Bertram", "Carlo", "Conrad", "David", "Frej", "Frode", "Harald", "Hugo", "Lauge",
                "Marius", "Markus", "Sander", "Sigurd", "Storm", "Tage", "Tim", "Torben", "Kåre", "Bjørn",
                "Børge", "Jørn", "Knud", "Leif", "Steen", "Bent", "Erling", "Henning", "Kjeld", "Bjarne",
                "Dan", "Mike", "Nick", "Ronnie", "Jimmy", "Kevin", "Mark", "Ken", "Joachim", "Mika",
                "Filip", "Robert", "Jimmi", "Mogens", "Mathis", "Bastian", "Benny", "Sylvester", "Tue", "Vilhelm",
                "Ebbe", "Mohamed", "Ahmed", "Ali", "Omar", "Hassan", "Hussein", "Mustafa", "Ibrahim", "Yusuf",
                "Emre", "Mehmet", "Kerem", "Burak", "Adam", "Amir", "Bilal", "Hamza", "Karim", "Malik",
                "Ismail", "Younes", "Tariq", "Zakaria", "Abdi", "Khaled", "Mahmoud", "Nadim", "Rami", "Samir",
                "Sami", "Erdal", "Deniz", "Can", "Okan", "Musa", "Adem", "Kamil", "Marko", "Luka",
                "Nikola", "Dino", "Edin", "Emir", "Haris", "Mirza", "Kelvin", "Junior", "Ardit", "Dardan",
                "Kingsley", "Mohammed", "Ludvig", "Arne", "Asbjørn", "Birk", "Christopher", "Elliot", "Ferdinand", "Holger",
                "Julius", "Karl", "Kaj", "Kurt", "Loke", "Nils", "Ove", "Rolf", "Stig", "Thorbjørn",
                "Tommy", "Uffe", "Aron", "Isak", "Liam", "Milas", "Noel", "Viggo", "Vitus", "Gunnar",
                "Carsten", "Ayoub", "Youssef", "Hakan", "Serkan", "Arda", "Baran", "Ilias", "Idris", "Anis"
            ],
            [
                "Nielsen", "Jensen", "Hansen", "Pedersen", "Andersen", "Christensen", "Larsen", "Sørensen", "Rasmussen", "Jørgensen",
                "Petersen", "Madsen", "Kristensen", "Olsen", "Thomsen", "Christiansen", "Poulsen", "Johansen", "Møller", "Mortensen",
                "Knudsen", "Jakobsen", "Mikkelsen", "Frederiksen", "Laursen", "Schmeichel", "Eriksen", "Højbjerg", "Kjær", "Dolberg",
                "Hjulmand", "Højlund", "Damsgaard", "Lindstrøm", "Vestergaard", "Delaney", "Nørgaard", "Wind", "Skov", "Braithwaite",
                "Bah", "Dorgu", "Isaksen", "Harder", "Biereth", "Grønbæk", "Frendrup", "Rønnow", "Hermansen", "Kvistgaarden",
                "Nelsson", "Dreyer", "Bruun Larsen", "Skov Olsen", "Kristiansen", "Daramy", "Ali", "Hassan", "Yilmaz", "Ahmed",
                "Agger", "Laudrup", "Tomasson", "Bendtner", "Rommedahl", "Gravesen", "Kahlenberg", "Bech", "Berg", "Bertelsen",
                "Bjerregaard", "Clausen", "Dam", "Dahl", "Holm", "Iversen", "Jeppesen", "Juhl", "Juul", "Kjeldsen",
                "Krogh", "Lauridsen", "Lund", "Lauritsen", "Mathiasen", "Nissen", "Overgaard", "Svendsen", "Søndergaard", "Thygesen",
                "Vinther", "Villadsen", "Winther", "Østergaard", "Ravn", "Bang", "Friis", "Holst", "Kjærgaard", "Lassen"
            ]),

        [Country.Morocco] = new(
            [
                "Achraf", "Hakim", "Youssef", "Sofyan", "Noussair", "Romain", "Yassine", "Azzedine", "Selim", "Abdelhamid",
                "Bilal", "Munir", "Zakaria", "Abde", "Ilias", "Amine", "Ayoub", "Brahim", "Abdessamad", "Hamza",
                "Mehdi", "Nayef", "Oussama", "Rachid", "Said", "Soufiane", "Tarik", "Walid", "Yahya", "Younes",
                "Mohamed", "Ahmed", "Omar", "Karim", "Adil", "Badr", "Anass", "Ismael", "Jawad", "Khalid",
                "Mounir", "Nabil", "Reda", "Samir", "Taha", "Yasser", "Imran", "Othmane", "Adam", "Driss",
                "Abdelaziz", "Abdelkader", "Abdellah", "Abdelilah", "Abdelkarim", "Abdellatif", "Abdelali", "Abdelmajid", "Abderrahim", "Abderrahmane",
                "Abdeslam", "Abdelhak", "Abdelghani", "Adnane", "Akram", "Ali", "Allal", "Amir", "Anouar", "Aziz",
                "Aymane", "Bouchaib", "Chadi", "Chakib", "Chouaib", "Fayçal", "Fouad", "Ghali", "Hafid", "Hamid",
                "Hassan", "Hatim", "Hicham", "Houssine", "Ibrahim", "Imad", "Ismail", "Issam", "Jamal", "Kamal",
                "Lahcen", "Larbi", "Marouane", "Mohammed", "Mostafa", "Mouad", "Mouhcine", "Mourad", "Moussa", "Mustapha",
                "Najib", "Nordin", "Noureddine", "Rayan", "Redouane", "Saad", "Sabir", "Salaheddine", "Sami", "Taoufik",
                "Zouhair", "Ziyad", "Adel", "Eliesse", "Chemsdine", "Neil", "Abdelkabir", "Abderrazak", "Fahd", "Jalal",
                "Khalil", "Nacer", "Rabie", "Riad", "Saber", "Wael", "Zaid", "Yuba", "Anir", "Amayas",
                "Ziri", "Oualid", "Nassim", "Yanis", "Abdeljalil", "Abdennour", "Badreddine", "Faouzi", "Houssam", "Nouh",
                "Sabri", "Salah", "Seddik", "Soulaimane", "Hamdi", "Haitam", "Jihad", "Kacem", "Mahmoud", "Mohcine",
                "Moncef", "Mounim", "Nizar", "Wadie", "Yazid", "Abdelouahed", "Abdelfettah", "Ilyes", "Amin", "Aymen",
                "Jaouad", "Hakam", "Yasin", "Mouhsine", "Rayane", "Souhail", "Tawfiq", "Yunes", "Adib", "Ammar",
                "Anwar", "Habib", "Hachim", "Hosni", "Idir", "Ilyass", "Jabir", "Kamil", "Lotfi", "Mahdi",
                "Malik", "Marwan", "Nabih", "Nadir", "Nasser", "Rafik", "Rami", "Ridouane", "Sanad", "Sohaib",
                "Tayeb", "Wassim", "Yacine", "Zakariae", "Zayd", "Abdou", "Aimen", "Amjad", "Bader", "Bassam",
                "Chafik", "Charaf", "Fares", "Firas", "Hassane", "Hilal", "Houcine", "Jalil", "Kenzi", "Khalifa",
                "Lyes", "Mamoun", "Mohssine", "Noam", "Rachad", "Ramzi", "Saïd", "Saïf", "Samy", "Soufian",
                "Tarek", "Wahib", "Younès", "Zakarya", "Ismaël", "Abdelmalek", "Abdelmoula", "Bouabid", "Hammou", "Lhoussaine",
                "Mbarek", "Moha", "Mimoun", "Abdessalam", "Ahmad", "Aissa", "Amr", "Ayman", "Bachir", "Chaker",
                "Farid", "Hamada", "Hassine", "Idriss", "Jawhar", "Karam", "Lamine", "Abdelbasset", "Abdelhadi", "Yassir"
            ],
            [
                "Alaoui", "Benali", "El Idrissi", "Bennani", "Tazi", "Amrani", "Berrada", "Fassi", "Chraibi", "Lahlou",
                "Saidi", "Ouazzani", "Haddad", "El Amrani", "Bouzidi", "Ziyech", "Hakimi", "Amrabat", "Mazraoui", "Aguerd",
                "Saïss", "En-Nesyri", "Boufal", "Ounahi", "Bounou", "Aboukhlal", "Ezzalzouli", "Attiat-Allah", "Dari", "Sabiri",
                "Ben Seghir", "Talbi", "El Kaabi", "Hamdallah", "Amallah", "El Khannouss", "Akhomach", "Saibari", "Zaroury", "El Aynaoui",
                "Belammari", "Chair", "El Azzouzi", "Harit", "Louza", "Tissoudali", "El Haddadi", "Rahimi", "Benjelloun", "Bennis",
                "Kettani", "Sefrioui", "Tahiri", "Bensouda", "Cherkaoui", "Filali", "Hajji", "Jaidi", "Kabbaj", "Lamrani",
                "Mansouri", "Naciri", "Slimani", "Tounsi", "Zerouali", "Aït Bennasser", "Boussoufa", "Belhanda", "Hadji", "Chamakh",
                "El Ahmadi", "Benatia", "Dirar", "Kharja", "Taarabt", "Fajr", "Bouhaddouz", "Nakach", "El Karti", "El Kaddouri",
                "Jabrane", "Tagnaouti", "Mohamedi", "Moutaraji", "Chibi", "Benhalib", "Bouchouari", "Alami", "Benkirane", "Sqalli",
                "Guessous", "Laraki", "Benchekroun", "Bouazza", "Bakkali", "Belkadi", "Boukhari", "Daoudi", "Ennaji", "Hamdaoui"
            ]),
    };
    private static readonly Dictionary<Country, NamePool> TeamPools = new()
    {
        [Country.Turkey] = new(
            [
                "Adana", "Adıyaman", "Afyon", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir",
                "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli",
                "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari",
                "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir",
                "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir",
                "Niğde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat",
                "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman",
                "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye",
                "Düzce", "Anadolu", "Karadeniz", "Ege", "Akdeniz", "Trakya", "Bozkurt", "Kapadokya", "Toros", "Fırat"
            ],
            [
                "Spor Kulübü", "Futbol Kulübü", "Spor", "FK", "SK", "Gençlik Spor", "Belediyespor", "İdman Yurdu", "Gücü", "Demirspor",
                "Gençlerbirliği", "İdman Ocağı", "Spor A.Ş.", "Sportif"
            ]),

        [Country.Germany] = new(
            [
                "Berlin", "Hamburg", "München", "Köln", "Frankfurt", "Stuttgart", "Düsseldorf", "Dortmund", "Essen", "Leipzig",
                "Bremen", "Dresden", "Hannover", "Nürnberg", "Duisburg", "Bochum", "Wuppertal", "Bielefeld", "Bonn", "Münster",
                "Mannheim", "Karlsruhe", "Augsburg", "Wiesbaden", "Gelsenkirchen", "Mönchengladbach", "Braunschweig", "Kiel", "Aachen", "Freiburg",
                "Rostock", "Magdeburg", "Kaiserslautern", "Mainz", "Paderborn", "Darmstadt", "Heidenheim", "Fürth", "Regensburg", "Osnabrück",
                "Saarbrücken", "Ulm", "Würzburg", "Jena", "Chemnitz", "Erfurt", "Lübeck", "Oldenburg", "Bayern", "Westfalen"
            ],
            [
                "FC", "SV", "SC", "FV", "Kickers", "Fußballclub", "Sportverein", "1860", "1899", "04",
                "05", "09"
            ]),

        [Country.France] = new(
            [
                "Paris", "Marseille", "Lyon", "Toulouse", "Nice", "Nantes", "Montpellier", "Strasbourg", "Bordeaux", "Lille",
                "Rennes", "Reims", "Le Havre", "Saint-Étienne", "Toulon", "Grenoble", "Dijon", "Angers", "Nîmes", "Brest",
                "Le Mans", "Amiens", "Tours", "Limoges", "Metz", "Besançon", "Perpignan", "Orléans", "Rouen", "Caen",
                "Nancy", "Lorient", "Auxerre", "Troyes", "Lens", "Sochaux", "Guingamp", "Ajaccio", "Bastia", "Valenciennes",
                "Clermont", "Laval", "Niort", "Annecy", "Pau", "Rodez", "Bretagne", "Provence", "Normandie", "Alsace"
            ],
            [
                "FC", "AC", "SC", "Football Club", "Athletic Club", "Sporting Club", "Foot", "Olympique", "Union", "Racing"
            ]),

        [Country.Italy] = new(
            [
                "Roma", "Milano", "Napoli", "Torino", "Palermo", "Genova", "Bologna", "Firenze", "Bari", "Catania",
                "Venezia", "Verona", "Messina", "Padova", "Trieste", "Brescia", "Parma", "Taranto", "Prato", "Modena",
                "Reggio", "Perugia", "Livorno", "Cagliari", "Foggia", "Salerno", "Ferrara", "Rimini", "Sassari", "Monza",
                "Bergamo", "Pescara", "Vicenza", "Como", "Lecce", "Udine", "Empoli", "Cremona", "Frosinone", "Cosenza",
                "Ascoli", "Catanzaro", "Spezia", "Pisa", "Avellino", "Terni", "Siena", "Novara", "Sicilia", "Toscana"
            ],
            [
                "FC", "Calcio", "AC", "SS", "US", "Football Club", "1907", "1913", "Calcio 1919", "Sporting",
                "Athletic"
            ]),

        [Country.Spain] = new(
            [
                "Madrid", "Barcelona", "Valencia", "Sevilla", "Zaragoza", "Málaga", "Murcia", "Palma", "Bilbao", "Alicante",
                "Córdoba", "Valladolid", "Vigo", "Gijón", "Granada", "Elche", "Oviedo", "Santander", "Pamplona", "Almería",
                "San Sebastián", "Burgos", "Albacete", "Getafe", "Logroño", "Badajoz", "Salamanca", "Huelva", "Marbella", "Lleida",
                "Tarragona", "León", "Cádiz", "Jaén", "Ourense", "Girona", "Lugo", "Cáceres", "Castellón", "Huesca",
                "Leganés", "Mallorca", "Tenerife", "Las Palmas", "Cartagena", "Ibiza", "Andalucía", "Galicia", "Asturias", "Castilla"
            ],
            [
                "CF", "FC", "Club de Fútbol", "Fútbol Club", "CD", "UD", "SD", "Deportivo", "Atlético", "Balompié"
            ]),

        [Country.England] = new(
            [
                "London", "Manchester", "Liverpool", "Birmingham", "Leeds", "Sheffield", "Bristol", "Newcastle", "Nottingham", "Leicester",
                "Coventry", "Bradford", "Southampton", "Portsmouth", "Plymouth", "Derby", "Stoke", "Wolverhampton", "Sunderland", "Hull",
                "Brighton", "Reading", "Norwich", "Ipswich", "Oxford", "Cambridge", "York", "Exeter", "Blackburn", "Bolton",
                "Preston", "Burnley", "Middlesbrough", "Swindon", "Luton", "Watford", "Northampton", "Peterborough", "Huddersfield", "Blackpool",
                "Wigan", "Barnsley", "Rotherham", "Doncaster", "Carlisle", "Lincoln", "Gloucester", "Bath", "Yorkshire", "Lancashire"
            ],
            [
                "City", "United", "Town", "Rovers", "Athletic", "Wanderers", "Albion", "County", "FC", "Rangers",
                "Borough", "Villa", "Argyle", "Orient"
            ]),

        [Country.Brazil] = new(
            [
                "São Paulo", "Rio", "Belo Horizonte", "Salvador", "Fortaleza", "Recife", "Porto Alegre", "Curitiba", "Goiânia", "Belém",
                "Manaus", "Brasília", "Campinas", "Santos", "Natal", "Florianópolis", "Maceió", "João Pessoa", "Teresina", "Cuiabá",
                "Vitória", "Londrina", "Ribeirão Preto", "Juiz de Fora", "Joinville", "Uberlândia", "Sorocaba", "Caxias", "Pelotas", "Campina Grande",
                "Feira de Santana", "Aracaju", "Bragança", "Chapecó", "Criciúma", "Volta Redonda", "Paraná", "Bahia", "Ceará", "Goiás",
                "Pernambuco", "Minas", "Amazonas", "Sergipe", "Paraíba", "Mato Grosso", "Maranhão", "Pará", "Tocantins", "Piauí"
            ],
            [
                "FC", "EC", "SC", "Futebol Clube", "Esporte Clube", "Sport Club", "Atlético", "AC", "Clube", "Futebol"
            ]),

        [Country.Argentina] = new(
            [
                "Buenos Aires", "Córdoba", "Rosario", "Mendoza", "La Plata", "Tucumán", "Mar del Plata", "Salta", "Santa Fe", "San Juan",
                "Resistencia", "Neuquén", "Santiago del Estero", "Corrientes", "Posadas", "Bahía Blanca", "Paraná", "Jujuy", "Formosa", "San Luis",
                "La Rioja", "Catamarca", "Río Cuarto", "Comodoro Rivadavia", "Avellaneda", "Quilmes", "Lanús", "Banfield", "Tigre", "Lomas de Zamora",
                "Morón", "San Martín", "Tandil", "Junín", "Rafaela", "Sarandí", "Florencio Varela", "Patagonia", "Pampa", "Ushuaia",
                "Chaco", "Misiones", "Entre Ríos", "San Nicolás", "Olavarría", "Pergamino", "Concordia", "Villa María", "Trelew", "Bariloche"
            ],
            [
                "Central", "Juniors", "FC", "Fútbol Club", "Atlético", "Unidos", "Sporting", "Athletic", "Deportivo", "Independiente"
            ]),

        [Country.Uruguay] = new(
            [
                "Montevideo", "Salto", "Paysandú", "Las Piedras", "Rivera", "Maldonado", "Tacuarembó", "Melo", "Mercedes", "Artigas",
                "Minas", "San José", "Durazno", "Florida", "Treinta y Tres", "Rocha", "Colonia", "Fray Bentos", "Canelones", "Punta del Este",
                "Carmelo", "Young", "Pando", "Juan Lacaze", "Dolores", "Bella Unión", "Nueva Helvecia", "Trinidad", "Pocitos", "Cerro",
                "Malvín", "Carrasco", "Prado", "Buceo", "Cordón", "La Teja", "Belvedere", "Sayago", "Colón", "Piedras Blancas",
                "Charrúa", "Oriental", "Celeste", "Garra", "Atlántida", "Piriápolis", "Chuy", "Santa Lucía", "Sarandí del Yí", "Platense"
            ],
            [
                "FC", "Fútbol Club", "Wanderers", "Juniors", "Atlético", "Sporting", "Deportivo", "Central", "Football Club", "Unidos"
            ]),

        [Country.Holland] = new(
            [
                "Amsterdam", "Rotterdam", "Den Haag", "Utrecht", "Eindhoven", "Groningen", "Tilburg", "Almere", "Breda", "Nijmegen",
                "Enschede", "Haarlem", "Arnhem", "Zaandam", "Amersfoort", "Apeldoorn", "Den Bosch", "Maastricht", "Leiden", "Dordrecht",
                "Zoetermeer", "Zwolle", "Leeuwarden", "Emmen", "Venlo", "Delft", "Deventer", "Heerenveen", "Alkmaar", "Helmond",
                "Hengelo", "Sittard", "Waalwijk", "Volendam", "Kerkrade", "Almelo", "Doetinchem", "Oss", "Velsen", "Hilversum",
                "Gouda", "Assen", "Roosendaal", "Friesland", "Brabant", "Limburg", "Holland", "Oranje", "Zeeland", "Twente"
            ],
            [
                "FC", "SC", "VV", "Boys", "Eagles", "Stars", "United", "'08", "Sport", "Voetbalclub"
            ]),

        [Country.Portugal] = new(
            [
                "Lisboa", "Porto", "Braga", "Coimbra", "Funchal", "Setúbal", "Aveiro", "Faro", "Guimarães", "Viseu",
                "Leiria", "Évora", "Vila Real", "Barcelos", "Famalicão", "Chaves", "Estoril", "Portimão", "Olhão", "Covilhã",
                "Santarém", "Bragança", "Beja", "Castelo Branco", "Guarda", "Viana do Castelo", "Paços de Ferreira", "Vizela", "Arouca", "Felgueiras",
                "Penafiel", "Amadora", "Oeiras", "Sintra", "Cascais", "Almada", "Barreiro", "Matosinhos", "Gondomar", "Maia",
                "Póvoa de Varzim", "Vila do Conde", "Tondela", "Madeira", "Açores", "Algarve", "Minho", "Alentejo", "Lusitano", "Ribatejo"
            ],
            [
                "FC", "SC", "Futebol Clube", "Sporting Clube", "Atlético", "AC", "Desportivo", "União", "Académico", "Clube"
            ]),

        [Country.Belgium] = new(
            [
                "Brussel", "Antwerpen", "Gent", "Charleroi", "Liège", "Brugge", "Namur", "Leuven", "Mons", "Mechelen",
                "Aalst", "Hasselt", "Kortrijk", "Oostende", "Sint-Niklaas", "Genk", "Seraing", "Roeselare", "Mouscron", "Verviers",
                "Waregem", "Beveren", "Lokeren", "Lommel", "Westerlo", "Eupen", "Tubize", "Tournai", "Wavre", "Turnhout",
                "Geel", "Knokke", "Ninove", "Ronse", "Deinze", "Virton", "Arlon", "Dinant", "Bastogne", "Spa",
                "Ieper", "Diest", "Tienen", "Vlaanderen", "Wallonie", "Flandria", "Kempen", "Ardennen", "Brabant", "Limburg"
            ],
            [
                "FC", "SC", "SV", "KV", "United", "Sporting", "Union", "Racing", "Olympic", "Football Club"
            ]),

        [Country.Croatia] = new(
            [
                "Zagreb", "Split", "Rijeka", "Osijek", "Zadar", "Pula", "Slavonski Brod", "Karlovac", "Varaždin", "Šibenik",
                "Sisak", "Vinkovci", "Velika Gorica", "Dubrovnik", "Bjelovar", "Koprivnica", "Vukovar", "Čakovec", "Požega", "Zaprešić",
                "Samobor", "Makarska", "Sinj", "Solin", "Kaštela", "Trogir", "Imotski", "Metković", "Knin", "Gospić",
                "Virovitica", "Đakovo", "Poreč", "Rovinj", "Umag", "Opatija", "Krk", "Hvar", "Korčula", "Brač",
                "Dalmacija", "Slavonija", "Istra", "Zagorje", "Lika", "Podravina", "Jadran", "Kvarner", "Croatia", "Posavina"
            ],
            [
                "NK", "HNK", "FC", "Nogometni Klub", "Dinamo", "Lokomotiva", "Sloga", "Jedinstvo", "Uskok", "Mladost",
                "Radnik"
            ]),

        [Country.Colombia] = new(
            [
                "Bogotá", "Medellín", "Cali", "Barranquilla", "Cartagena", "Cúcuta", "Bucaramanga", "Pereira", "Santa Marta", "Ibagué",
                "Pasto", "Manizales", "Neiva", "Villavicencio", "Armenia", "Valledupar", "Montería", "Sincelejo", "Popayán", "Tunja",
                "Palmira", "Envigado", "Rionegro", "Itagüí", "Bello", "Soacha", "Tuluá", "Buenaventura", "Girardot", "Riohacha",
                "Quibdó", "Florencia", "Yopal", "Sogamoso", "Duitama", "Zipaquirá", "Cartago", "Apartadó", "Leticia", "San Andrés",
                "Antioquia", "Valle", "Caribe", "Llanos", "Santander", "Boyacá", "Tolima", "Huila", "Cauca", "Pacífico"
            ],
            [
                "FC", "Fútbol Club", "Deportivo", "Atlético", "Independiente", "Real", "Unión", "Junior", "Nacional", "Sporting"
            ]),

        [Country.Mexico] = new(
            [
                "Ciudad de México", "Guadalajara", "Monterrey", "Puebla", "Tijuana", "León", "Juárez", "Zapopan", "Mérida", "San Luis Potosí",
                "Aguascalientes", "Querétaro", "Hermosillo", "Saltillo", "Mexicali", "Culiacán", "Chihuahua", "Morelia", "Toluca", "Cancún",
                "Torreón", "Acapulco", "Tampico", "Veracruz", "Oaxaca", "Durango", "Mazatlán", "Pachuca", "Tuxtla", "Villahermosa",
                "Celaya", "Irapuato", "Zacatecas", "Tepic", "Colima", "Cuernavaca", "Tlaxcala", "Campeche", "Ensenada", "Los Mochis",
                "Jalisco", "Sonora", "Yucatán", "Sinaloa", "Bajío", "Azteca", "Maya", "Chiapas", "Michoacán", "Tabasco"
            ],
            [
                "FC", "Fútbol Club", "Atlético", "Unidos", "Deportivo", "Real", "Toros", "Águilas", "Jaguares", "Leones",
                "Halcones", "Tigres", "Venados", "Dorados", "Potros"
            ]),

        [Country.Nigeria] = new(
            [
                "Lagos", "Kano", "Ibadan", "Abuja", "Port Harcourt", "Benin", "Kaduna", "Enugu", "Aba", "Onitsha",
                "Jos", "Ilorin", "Warri", "Owerri", "Abeokuta", "Calabar", "Uyo", "Akure", "Maiduguri", "Sokoto",
                "Katsina", "Bauchi", "Zaria", "Makurdi", "Minna", "Yola", "Gombe", "Lafia", "Asaba", "Umuahia",
                "Awka", "Ado-Ekiti", "Osogbo", "Ikorodu", "Ijebu", "Ogbomosho", "Oyo", "Ife", "Sapele", "Nsukka",
                "Rivers", "Plateau", "Kwara", "Delta", "Akwa Ibom", "Imo", "Niger", "Benue", "Ogun", "Edo"
            ],
            [
                "FC", "United", "Stars", "Rangers", "Pillars", "Sharks", "Warriors", "Tornadoes", "Lions", "City",
                "Royals", "Eagles"
            ]),

        [Country.Senegal] = new(
            [
                "Dakar", "Thiès", "Touba", "Rufisque", "Kaolack", "Mbour", "Saint-Louis", "Ziguinchor", "Diourbel", "Louga",
                "Tambacounda", "Kolda", "Richard-Toll", "Mbacké", "Tivaouane", "Kaffrine", "Fatick", "Matam", "Kédougou", "Sédhiou",
                "Pikine", "Guédiawaye", "Keur Massar", "Yoff", "Ouakam", "Ngor", "Médina", "Grand Yoff", "Parcelles", "Sicap",
                "Joal", "Saly", "Podor", "Bambey", "Linguère", "Dagana", "Bignona", "Vélingara", "Casamance", "Sine-Saloum",
                "Cayor", "Baol", "Teranga", "Baobab", "Niokolo", "Gorée", "Walo", "Djolof", "Lompoul", "Fouta"
            ],
            [
                "FC", "AS", "ASC", "US", "Sports", "Foot", "Olympique", "Union", "Lions", "Stars"
            ]),

        [Country.Japan] = new(
            [
                "Tokyo", "Yokohama", "Osaka", "Nagoya", "Sapporo", "Fukuoka", "Kobe", "Kawasaki", "Kyoto", "Saitama",
                "Hiroshima", "Sendai", "Chiba", "Kitakyushu", "Sakai", "Niigata", "Hamamatsu", "Kumamoto", "Sagamihara", "Shizuoka",
                "Okayama", "Kagoshima", "Kashima", "Kashiwa", "Urawa", "Shimizu", "Iwata", "Kofu", "Matsumoto", "Kanazawa",
                "Toyama", "Nagasaki", "Oita", "Tokushima", "Matsuyama", "Kochi", "Machida", "Mito", "Utsunomiya", "Akita",
                "Yamagata", "Fukushima", "Gifu", "Nara", "Okinawa", "Tochigi", "Gunma", "Ehime", "Tosu", "Shonan"
            ],
            [
                "FC", "SC", "United", "Samurai", "Sakura", "Ronin", "Phoenix", "Falcons", "Red Stars", "Blue Waves",
                "Thunder", "Dolphins"
            ]),

        [Country.Denmark] = new(
            [
                "København", "Aarhus", "Odense", "Aalborg", "Esbjerg", "Randers", "Kolding", "Horsens", "Vejle", "Roskilde",
                "Herning", "Silkeborg", "Næstved", "Fredericia", "Viborg", "Køge", "Holstebro", "Taastrup", "Slagelse", "Hillerød",
                "Holbæk", "Sønderborg", "Svendborg", "Hjørring", "Frederikshavn", "Haderslev", "Skive", "Ringsted", "Nykøbing", "Lyngby",
                "Brøndby", "Hvidovre", "Gentofte", "Gladsaxe", "Glostrup", "Herlev", "Ballerup", "Helsingør", "Thisted", "Skanderborg",
                "Ikast", "Varde", "Grenaa", "Jylland", "Sjælland", "Fyn", "Bornholm", "Nordsjælland", "Lolland", "Dannebrog"
            ],
            [
                "FC", "IF", "BK", "FF", "IK", "Boldklub", "Fodboldklub", "Idrætsforening", "United", "Sport"
            ]),

        [Country.Morocco] = new(
            [
                "Casablanca", "Rabat", "Fès", "Marrakech", "Tanger", "Agadir", "Meknès", "Oujda", "Kénitra", "Tétouan",
                "Safi", "Temara", "Mohammedia", "Khouribga", "El Jadida", "Béni Mellal", "Nador", "Taza", "Settat", "Berrechid",
                "Khémisset", "Guelmim", "Larache", "Ksar El Kébir", "Berkane", "Khénifra", "Ouarzazate", "Errachidia", "Essaouira", "Tiznit",
                "Taroudant", "Al Hoceïma", "Laâyoune", "Dakhla", "Ifrane", "Chefchaouen", "Azrou", "Sidi Kacem", "Sidi Slimane", "Youssoufia",
                "Atlas", "Rif", "Sahara", "Souss", "Maghreb", "Chaouia", "Doukkala", "Tafilalet", "Gharb", "Draa"
            ],
            [
                "FC", "AC", "CA", "AS", "Olympique", "Union", "Renaissance", "Ittihad", "Chabab", "Kawkab"
            ]),
    };
    public static string PlayerNameGenerate(Country country) => Pick(PlayerPools[country].FirstNames)+" "+Pick(PlayerPools[country].LastNames);
    public static string TeamNameGenerate(Country country) => Pick(TeamPools[country].FirstNames)+" "+Pick(TeamPools[country].LastNames);

    public static string StadiumNameGenerate(Country country, string teamName)
    {
        string city = TeamPools[country].FirstNames
            .Where(c => teamName.StartsWith(c + " "))
            .OrderByDescending(c => c.Length)
            .First();

        return country switch
        {
            Country.Turkey => $"{city} Stadyumu",
            Country.England or Country.Nigeria or Country.Japan => $"{city} Stadium",
            Country.Germany or Country.Croatia => $"Stadion {city}",
            Country.Holland or Country.Denmark => $"{city} Stadion",
            Country.France or Country.Belgium or Country.Senegal or Country.Morocco => "Stade " + FrenchOf(city),
            Country.Italy => $"Stadio {city}",
            Country.Spain or Country.Argentina or Country.Uruguay or Country.Colombia or Country.Mexico => $"Estadio {city}",
            Country.Brazil or Country.Portugal => $"Estádio {city}",
            _ => throw new ArgumentOutOfRangeException(nameof(country), country, null),
        };
    }
    
    private static string FrenchOf(string city) =>
        city.StartsWith("Le ") ? "du " + city[3..]
        : "AEIOUYÉÈÊÎÔ".Contains(char.ToUpperInvariant(city[0])) ? "d'" + city
        : "de " + city;
    
    private static string Pick(string[] items) => items[Rng.Next(items.Length)];
}
