<template>

<form class="space-y-6">
    <h3>Add Set</h3>

    <FormField name="date">
        <FormItem v-auto-animate>
            <FormLabel for="date">Date</FormLabel>
            <FormControl>
                <Input id="date" v-model="form.date" type="date" placeholder="Date" />
            </FormControl>
            <FormDescription>Date the set was completed</FormDescription>
        </FormItem>
    </FormField>

    <FormField name="repsCount">
        <FormItem v-auto-animate>
            <FormLabel for="repsCount">Number of Reps</FormLabel>
            <FormControl>
                <Input id="repsCount" v-model="form.repCount" type="number" placeholder="Number of Reps" />
            </FormControl>
            <FormDescription>Number of reps in the set.</FormDescription>
        </FormItem>
    </FormField>

    <FormField name="weight">
        <FormItem v-auto-animate>
            <FormLabel for="weight">Weight</FormLabel>
            <FormControl>
                <Input id="weight" v-model="form.weight" type="number" placeholder="Weight" />
            </FormControl>
            <FormDescription>Weight for the set.</FormDescription>
        </FormItem>
    </FormField>

    <PopoverClose>
        <Button class="w-full" type="button" @click="createExerciseSet()">Add Set</Button>
    </PopoverClose>

</form>

</template>

<script setup lang="ts">
import type { TExercise } from '~/types/TExercise';
import type { TExerciseSet } from '~/types/TExerciseSet';
import { Input } from '@/components/ui/input'
import { toDate } from 'radix-vue/date'
import {
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from '@/components/ui/form'
import { PopoverClose } from 'radix-vue';
import { parseDate } from '@internationalized/date';
import { apiClients } from '~/utils/api/ApiClients';

export type TCreateExerciseSetFormProps = {
    exercise: TExercise;
}

const emit = defineEmits(['creation'])

const props = withDefaults(defineProps<TCreateExerciseSetFormProps>(), {});

const form = reactive<TExerciseSet>({
    exerciseId: props.exercise.id ?? 0,
    repCount: 6,
    weight: props.exercise.maximumWeight ?? 0
});

function clearForm() {
    form.date = '';
    form.repCount = 6;
    form.weight = props.exercise.maximumWeight ?? 0;
}

async function createExerciseSet() {
    await apiClients.set.create(form);
    clearForm();
    emit('creation');
}

</script>

<style scoped></style>