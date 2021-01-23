import produce from 'immer'
import { GetState, SetState, StateCreator } from 'zustand'
import { StateCombined } from '../modules'

export const userInitialState = {
  currentSemester: {
    key: '',
    name: '',
  },
  semesters: undefined as undefined | Record<string, string>,
}

export type UserStateCombined = typeof userInitialState & {
  actions: {
    semesterActions: {
      setSemesters: (semesters: Record<string, string>) => void
    }
    semesterSelectors: {
      areSemestersFetched: () => boolean
    }
  }
}

export const userStateCombined = (
  set: SetState<StateCombined>,
  get: GetState<StateCombined>,
): UserStateCombined => ({
  actions: {
    semesterActions: {
      setSemesters: (semesters) => {
        set((prev) =>
          produce(prev, (newState) => {
            const semesterKeys = semesters && Object.keys(semesters) // TODO
            newState.user.semesters = semesters
            if (semesterKeys.length > 0) {
              const currentSemesterKey = semesterKeys[0]
              const currentSemesterName = semesters[currentSemesterKey]
              newState.user.currentSemester.key = semesterKeys[0]
              newState.user.currentSemester.name = currentSemesterName
            }
          }),
        )
      },
    },
    semesterSelectors: {
      areSemestersFetched: () => get().user.semesters !== undefined,
    },
  },
  ...userInitialState,
})
