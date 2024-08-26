<template>

    <RouterLink :to="`/exercises/${exercise.id}`" class="exercise-card">

        <div class="image-container">
            <img src="https://blogscdn.thehut.net/app/uploads/sites/478/2021/01/calories-weight-lifting-HERO-min_1642171338.jpg" alt="weight">
        </div>

        <h3 class="name">
            {{ exercise.name }}
        </h3>

        <div class="badges">
            
            <Badge v-if="(exercise.maximumWeight ?? 0) > 0" type="success">
                {{ exercise.maximumWeight }}kg One Rep Max
            </Badge>

        </div>

    </RouterLink>

</template>

<script setup lang="ts">
import type { TExercise } from '~/types/TExercise';

export type ExerciseCardProps = {
    exercise: TExercise;
}

const props = withDefaults(defineProps<ExerciseCardProps>(), {});
    
const exercise = computed(() => props.exercise);

</script>

<style scoped>

.exercise-card {
    background: var(--base-white);
    border: 1px solid var(--gray--200);
    padding: 16px;
    box-shadow: 0px 4px 8px -2px rgba(16, 24, 40, 0.1), 0px 2px 4px -2px rgba(16, 24, 40, 0.06);
    border-radius: 12px;
    width: 400px;

    display: grid;
    grid-template-rows: 225px 48px;
    grid-gap: 16px;

    cursor: pointer;
}

.exercise-card:hover .image-container img {
    transform: scale(1.1);
    filter: blur(4px);
}

.image-container {
    display: flex;
    justify-content: center;
    align-items: center;
    overflow: hidden;
    border-radius: 10px;
}

.image-container img {
    height: 100%;
    transition: 0.3s;
    object-fit: cover;
}

.name {
    text-overflow: ellipsis;
    overflow: hidden;
}

</style>