export type TExerciseSet = {
    id?: number,
    exerciseId: number,
    
    date?: Date,
    repsCount?: number,
    weight?: number,    
    
    createdOn?: Date,
    lastUpdatedOn?: Date,
    archivedOn?: Date,
};