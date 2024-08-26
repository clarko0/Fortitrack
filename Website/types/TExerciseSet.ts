export type TExerciseSet = {
    id?: number,
    exerciseId: number,
    
    date?: string,
    repCount?: number,
    weight?: number,    
    
    createdOn?: Date,
    lastUpdatedOn?: Date,
    archivedOn?: Date,
};