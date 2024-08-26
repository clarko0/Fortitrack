<template>

    <Popover>
        <PopoverTrigger>
          <Button variant="outline">Create Exercise</Button>
        </PopoverTrigger>
        <PopoverContent>
            <CreateExerciseForm @creation="fetchExercises()"/>
        </PopoverContent>
    </Popover>

    <div class="cards-container">
        <ExerciseCard v-if="allExercises && allExercises.length > 0" v-for="(exercise, index) in allExercises" :exercise="exercise" />
    </div>

</template>

<script setup lang="ts">
import { apiClients } from '~/utils/api/ApiClients';
import { ExerciseCard } from '#components';
import { callWithNuxt, type NuxtError } from '#app';
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from '@/components/ui/popover'
import type { TExercise } from '~/types/TExercise';

useAsyncData(async () => {

    const nuxtApp = useNuxtApp();

    try {
        await fetchExercises();
    }
    catch (e: unknown) {
        const err = e as NuxtError;
        callWithNuxt(nuxtApp, showError, [err]);
    }
    
});

const data = reactive({
    allExercises: [] as TExercise[]
});

async function fetchExercises() {
    const exercises = await apiClients.exercise.list();
    data.allExercises = exercises;
}

const allExercises = computed(() => data?.allExercises);

</script>

<style scoped>

.cards-container {
    display: flex;
    flex-wrap: wrap;
    width: 100%;
    margin-top: 2em;
    grid-gap: 1em;
}

</style>