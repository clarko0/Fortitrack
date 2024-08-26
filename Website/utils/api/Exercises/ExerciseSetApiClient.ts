import { BaseApiClient, type TApiClientResponse } from "../BaseApiClient";
import type { TExerciseSet } from "~/types/TExerciseSet";

export const exerciseSetApiClient = {
    client: new BaseApiClient("http://localhost:3001/sets"),

    list: async () : Promise<TExerciseSet[]> => {
        const response = await exerciseSetApiClient.client.get<TExerciseSet[]>("?");
        return response;
    },

    getById: async (id : number) : Promise<TExerciseSet> => {
        const response = await exerciseSetApiClient.client.get<TExerciseSet>(`/${id}`);
        return response;
    },

    create: async (set : TExerciseSet) : Promise<TExerciseSet> => {
        const response = await exerciseSetApiClient.client.put<TExerciseSet>("", set);
        return response;
    },

    update: async (set : TExerciseSet) : Promise<TExerciseSet> => {
        const response = await exerciseSetApiClient.client.put<TExerciseSet>("", set);
        return response;
    },
};