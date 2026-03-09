import { count } from 'node:console';
import { ITaskScheduler_621 } from '../Interfaces/Medium/ITaskScheduler_621';

export class TaskScheduler_Math_621 implements ITaskScheduler_621 {
    leastInterval(_tasks: string[], _n: number): number {
        if (_tasks.length == 0) return 0;
        let [maxFrequency, groupSize] = this.aggregate(_tasks);

        let candidateSize =  (maxFrequency - 1) * (_n + 1) + groupSize;

        return Math.max(candidateSize, _tasks.length);
    }

    aggregate(_tasks: string[]) : [maxFrequency: number, groupSize: number]
    {
        let maxFrequency = 0;
        let groupSize = 0;
        let counts : number[] = new Array(26).fill(0);
        
        for (let i : number = 0; i < _tasks.length; i++) 
        {
            var intTask : number = _tasks[i]!.charCodeAt(0) - 'A'.charCodeAt(0);
            counts[intTask]! += 1;
            maxFrequency = Math.max(maxFrequency, counts[intTask]!);
        }        
        groupSize = 0;
        for(let i: number = 0; i < counts.length; i++) {
            if (counts[i] == maxFrequency) groupSize++;
        }
        
        return [maxFrequency, groupSize];
    }
}
