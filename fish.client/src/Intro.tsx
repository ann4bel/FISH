import rules from './assets/rules.png';
import new_game from './assets/new_game.png';
import fish_logo from './assets/fish.png';
import CSS from "csstype";

function Intro() {
    const middle_image: CSS.Properties = {
        margin: "0 300px",
    };
    return (
        <div id="intro">
            <img src={rules} alt="RULES" />
            <img src={fish_logo} style={middle_image} alt="FISH" />
            <button><img src={new_game} alt="NEW_GAME" onClick={createNewGame} /></button>
       </div>
    );

    async function createNewGame() {
        const owner_name = 'annabel';

        // body is a JSON string
        await fetch('weatherforecast/newgame', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(owner_name)
            })
            .then(response => response.json())
            .then(() => {
                console.log('New Game is Created Successfully');
            })
            .catch(error => console.error('Unable to add item.', error));
    }
}

export default Intro;