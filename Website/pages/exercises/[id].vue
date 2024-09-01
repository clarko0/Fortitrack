<template>

    <div class="page-header">
        <RouterLink to="/" variant="outline">
            <Button variant="link" style="padding: 0;">Go Back</Button>
        </RouterLink>
        <h2>{{ exercise.name }}</h2>
        <div class="badges">

            <Badge v-if="(exercise.maximumWeight ?? 0) > 0" type="success">
                {{ exercise.maximumWeight }}kg
            </Badge>

        </div>
    </div>

    <div class="page-content">

        <Popover>
            <PopoverTrigger>
              <Button variant="outline">Add Set</Button>
            </PopoverTrigger>
            <PopoverContent>
                <CreateExerciseSetForm :exercise="exercise" @creation="fetchExercise()"/>
            </PopoverContent>
        </Popover>
    
        <Table>
            <TableHeader>
                <TableRow>
                    <TableHead>Date</TableHead>
                    <TableHead>Weight</TableHead>
                    <TableHead>Reps</TableHead>
                    <TableHead class="text-right">Actions</TableHead>
                </TableRow>
            </TableHeader>
            <TableBody>
                <TableRow v-if="exercise.exerciseSets?.length == 0">
                    <TableCell colspan="3">No records found</TableCell>
                </TableRow>
    
                <TableRow v-for="record in exercise.exerciseSets" :key="record.id">
                    <TableCell>{{ dateString(record.date ?? "") }}</TableCell>
                    <TableCell>{{ record.weight }} kg</TableCell>
                    <TableCell>{{ record.repCount }}</TableCell>
                    <TableCell class="text-right">
                        <Button variant="destructive" @click="deleteRecord(record.id ?? 0)">Delete</Button>
                    </TableCell>
                </TableRow>
            </TableBody>
        </Table>

    </div>

</template>

<script setup lang="ts">
import { callWithNuxt, type NuxtError } from '#app';
import type { TExercise } from '~/types/TExercise';
import { apiClients } from '~/utils/api/ApiClients';
import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from '@/components/ui/table'
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from '@/components/ui/popover'


const route = useRoute();
const exerciseRouteId = computed(() => parseInt(route.params.id.toString()));

onMounted(async () => {

    const nuxtApp = useNuxtApp();

    try {
        await fetchExercise();
    }
    catch (e: unknown) {
        const err = e as NuxtError;
        callWithNuxt(nuxtApp, showError, [err]);
    }

});


const data = reactive({
    exercise: {} as TExercise
});

async function fetchExercise() {
    const exercise = await apiClients.exercise.getById(exerciseRouteId.value);
    data.exercise = exercise;
}

async function deleteRecord(id: number) {
    await apiClients.set.archive(id);
    await fetchExercise();
}

function dateString(date: string) {
    return new Date(date).toLocaleDateString('en-GB', { day: 'numeric', month: 'short', year: 'numeric' });
}

const exercise = computed(() => data.exercise);


</script>

<style scoped>

.page-content {
    margin-top: 2em;
}

.badges {
    display: flex;
    gap: 1em;
    margin-top: 0.5em;
    
}

</style>