import type { TExerciseSet } from "./TExerciseSet";

export type TExercise = {
    id?: number,
    name?: string,

    exerciseSets : TExerciseSet[],
    
    createdOn?: Date,
    lastUpdatedOn?: Date,
    archivedOn?: Date,
};