<template>

    <div>
        <ExerciseCard v-if="allExercises && allExercises.length > 0" v-for="(exercise, index) in allExercises" :exercise="exercise" />
    </div>

</template>

<script setup lang="ts">
import { apiClients } from '~/utils/api/ApiClients';
import { ExerciseCard } from '#components';
import { callWithNuxt, type NuxtError } from '#app';

const { data } = useAsyncData(async () => {

    const nuxtApp = useNuxtApp();

    try {
        const allExercises = await apiClients?.exercise?.list();

        return {
            allExercises
        };
    }
    catch (e: unknown) {
        const err = e as NuxtError;
        callWithNuxt(nuxtApp, showError, [err]);
    }
    
});

const allExercises = computed(() => data?.value?.allExercises);

</script>

<style>

</style>