import { ITaskScheduler_621 } from '../../src/Interfaces/Medium/ITaskScheduler_621';
import { TaskScheduler_Math_621 } from '../../src/Medium/TaskScheduler_Math_621';

describe('TaskScheduler_621', () => {
    const implementations: [ITaskScheduler_621, string][] = [
        [new TaskScheduler_Math_621(), 'Math'],
    ];

    describe.each(implementations)('%s (%s)', (impl: ITaskScheduler_621, _name: string) => {

        // LeetCode example 1
        it('tasks=["A","A","A","B","B","B"], n=2 → 8', () => {
            expect(impl.leastInterval(['A','A','A','B','B','B'], 2)).toBe(8);
        });

        // LeetCode example 2: no cooldown, all tasks run back-to-back
        it('tasks=["A","A","A","B","B","B"], n=0 → 6', () => {
            expect(impl.leastInterval(['A','A','A','B','B','B'], 0)).toBe(6);
        });

        // LeetCode example 3: many tasks fill idle slots
        it('tasks=["A"x6,"B","C","D","E","F","G"], n=2 → 16', () => {
            expect(impl.leastInterval(['A','A','A','A','A','A','B','C','D','E','F','G'], 2)).toBe(16);
        });

        // Single task, no cooldown
        it('tasks=["A"], n=0 → 1', () => {
            expect(impl.leastInterval(['A'], 0)).toBe(1);
        });

        // Single task with large cooldown — no repetition needed, so idle is irrelevant
        it('tasks=["A"], n=10 → 1', () => {
            expect(impl.leastInterval(['A'], 10)).toBe(1);
        });

        // Three identical tasks with cooldown 2: A _ _ A _ _ A = 7
        it('tasks=["A","A","A"], n=2 → 7', () => {
            expect(impl.leastInterval(['A','A','A'], 2)).toBe(7);
        });

        // Two tasks alternating perfectly fill the cooldown — no idle needed
        it('tasks=["A","B","A","B"], n=1 → 4', () => {
            expect(impl.leastInterval(['A','B','A','B'], 1)).toBe(4);
        });

        // Longer cooldown forces more idle slots: A B _ _ A B _ _ A B = 10
        it('tasks=["A","A","A","B","B","B"], n=3 → 10', () => {
            expect(impl.leastInterval(['A','A','A','B','B','B'], 3)).toBe(10);
        });

        // All unique tasks — tasks fill every slot, no idle regardless of cooldown
        it('tasks=["A","B","C","D","E","F"], n=2 → 6', () => {
            expect(impl.leastInterval(['A','B','C','D','E','F'], 2)).toBe(6);
        });

        // Four identical tasks with cooldown 3: A _ _ _ A _ _ _ A _ _ _ A = 13
        it('tasks=["A","A","A","A"], n=3 → 13', () => {
            expect(impl.leastInterval(['A','A','A','A'], 3)).toBe(13);
        });

        // Two max-frequency tasks at the end: (freq-1)*(n+1) + countAtMax
        it('tasks=["A","A","A","B","B","B","C","C"], n=3 → 10', () => {
            // maxFreq=3 (A,B), countMaxFreq=2 → (3-1)*(3+1)+2=10; tasks.length=8 → max(10,8)=10
            expect(impl.leastInterval(['A','A','A','B','B','B','C','C'], 3)).toBe(10);
        });
    });
});
