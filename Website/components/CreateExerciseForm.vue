<template>
    <form class="space-y-6">
        <h3>Create Exercise</h3>

        <FormField name="name">
            <FormItem v-auto-animate>
                <FormLabel>Name</FormLabel>
                <FormControl>
                    <Input v-model="form.name" placeholder="Exercise name" />
                </FormControl>
                <FormDescription>Name of the exercise e.g. "Deadlift"</FormDescription>
            </FormItem>
        </FormField>

        <PopoverClose>
            <Button class="w-full" type="button" @click="createExercise()">Create</Button>
        </PopoverClose>
    </form>
</template>

<script setup lang="ts">
import { Input } from '@/components/ui/input'
import {
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from '@/components/ui/form'
import type { TExercise } from '~/types/TExercise';
import { apiClients } from '~/utils/api/ApiClients';
import { PopoverClose } from 'radix-vue';

const emit = defineEmits(['creation'])

const form = reactive<TExercise>({
    name: ''
})

function clearForm() {
    form.name = ''
}

async function createExercise() {
    await apiClients.exercise.create(form);
    clearForm();
    emit('creation');
}

</script>

<style scoped></style>