import useSWR from 'swr'
import { post, request } from './common/common'
import { v4 as uuidv4 } from 'uuid'
import { fetcher, Path } from '../api/axios'

interface ProjectProps {
  projectKey: string
}

export interface ProjectFormData {
  name: string
  typeDefinitionKey: string
  subjectKey: string
  categoryKey: string
  description: string
  projectStatusKey: string
  deadlineTime: Date
  necessaryToPass: boolean
}

type ProjectPost = ProjectFormData & ProjectProps

export const postProject = async (data: ProjectFormData) =>
  await post<ProjectPost>(Path.Project, {
    ...data,
    projectKey: uuidv4(),
  }).then((response) => response.status === 200)

export const useProjectTypes = () => {
  const { data, error } = useSWR<Record<string, string> | undefined>(
    'project/types',
    fetcher,
  )

  return { projectTypes: data, isLoading: !error && !data, isError: error }
}

export const useProjectStatuses = () => {
  const { data, error } = useSWR<Record<string, string> | undefined>(
    `project/statuses`,
    fetcher,
  )

  return { projectStatuses: data, isLoading: !error && !data, isError: error }
}

interface ProjectCategory {
  categoryKey: string
  categoryName: string
  projectTypeKey: string
}

export const useProjectCategory = (projectTypeKey: string | undefined) => {
  const { data, error } = useSWR<ProjectCategory[] | undefined>(
    projectTypeKey ? `project/categories/${projectTypeKey}` : null,
    fetcher,
  )

  return {
    projectCategories: data?.reduce((prev, newVal) => {
      const { categoryKey, categoryName } = newVal
      return { ...prev, [categoryKey]: categoryName }
    }, {}),
    isLoading: !error && !data,
    isError: error,
  }
}

export const useProjects = () => {}
