import type { TExerciseSet } from "./TExerciseSet";

export type TExercise = {
    id?: number,
    name?: string,

    maximumWeight?: number,
    exerciseSets? : TExerciseSet[],
    
    createdOn?: Date,
    lastUpdatedOn?: Date,
    archivedOn?: Date,
};