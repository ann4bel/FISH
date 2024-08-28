import { useEffect, useState } from 'react';
import './App.css';
import Intro from './Intro.tsx'

interface Game {
    id: number;
    size: number;
    totalSize: number;
    ownerName: string;
}

function App() {
    const [games, setGames] = useState<Game[]>();

    useEffect(() => {
        populateGameData();
    }, []);

    const contents = games === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. </em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Size</th>
                    <th>Total Size</th>
                    <th>Owner Name</th>
                </tr>
            </thead>
            <tbody>
                {games.map(game =>
                    <tr key={game.id}>
                        <td>{game.id}</td>
                        <td>{game.size}</td>
                        <td>{game.totalSize}</td>
                        <td>{game.ownerName}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <Intro />
            <h1 id="tableLabel">FISH</h1>
            {contents}
        </div>
    );

    async function populateGameData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        console.log(data);
        setGames(data);
    }
}

export default App;