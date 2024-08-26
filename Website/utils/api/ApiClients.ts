import { exerciseApiClient } from "./Exercises/ExerciseApiClient";
import { exerciseSetApiClient } from "./Exercises/ExerciseSetApiClient";

export const apiClients = {
    exercise: exerciseApiClient,
    set: exerciseSetApiClient,
}