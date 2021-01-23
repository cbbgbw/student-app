import { StateCombined } from '../modules'

export const getUserState = (state: StateCombined) => state.user

export const getViewState = (state: StateCombined) => state.view

export const setSemesters = (state: StateCombined) =>
  getUserState(state).actions.semesterActions.setSemesters
