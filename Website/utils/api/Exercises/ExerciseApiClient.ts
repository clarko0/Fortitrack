import type { TExercise } from "~/types/TExercise";
import { BaseApiClient, type TApiClientResponse } from "../BaseApiClient";

export const exerciseApiClient = {
    client: new BaseApiClient("http://localhost:3001/exercises"),

    list: async () : Promise<TExercise[]> => {
        const response = await exerciseApiClient.client.get<TExercise[]>("");
        return response;
    },

    getById: async (id : number) : Promise<TExercise> => {
        const response = await exerciseApiClient.client.get<TExercise>(`/${id}`);
        return response;
    },

    create: async (exercise : TExercise) : Promise<TExercise> => {
        const response = await exerciseApiClient.client.put<TExercise>("", exercise);
        return response;
    },

    update: async (exercise : TExercise) : Promise<TExercise> => {
        const response = await exerciseApiClient.client.put<TExercise>("", exercise);
        return response;
    },
};