const anExampleVariable = "Hello World"
console.log(anExampleVariable)


function calculateCounter(time: number[], distance: number[]): number {
    let result : number = 1;


    for (let i = 0; i < time.length; i++)
    {
    let counter = 0;
        for (let j = 0; j < time[i]; j++)
        {
            let timeLeft = time[i] - j;

            if (j * timeLeft > distance[i])
            {
                counter++;
            }
        }
        result *= counter;
    }
        return result;
}



// Beispielaufruf
let time : number[] = [7, 15, 30,];
let distance : number[] = [9, 40, 200];

let result = calculateCounter(time, distance);

console.log(result);