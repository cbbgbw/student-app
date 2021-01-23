import React, { useEffect, useState } from 'react'
import { Popover, PopoverArrow } from '@chakra-ui/popover'
import {
  Button,
  PopoverBody,
  PopoverCloseButton,
  PopoverContent,
  PopoverHeader,
  PopoverTrigger,
  Portal,
  Select,
} from '@chakra-ui/react'
import { SemesterNumberInput } from '../../../SemesterSelect'
import { Path, request } from '../../../../actions/common/common'
import { useUserSemesters } from '../../../../actions/user/useUserSemesters'

export const SelectSemesterPopover = () => {
  const { semesters, currentSemester, mutate } = useUserSemesters()

  const [selectedSemester, setSelectedSemester] = useState<string>()
  const [newSemesterNumber, setNewSemesterNumber] = useState<number>()

  useEffect(() => {
    setSelectedSemester(currentSemester?.[0])
    setNewSemesterNumber(Number(currentSemester?.[1]) + 1)
  }, [semesters])

  const generateSemestersItems = () =>
    semesters &&
    Object.keys(semesters).map((key: string) => (
      <option selected={key === currentSemester?.[0]} key={key} value={key}>
        Semestr {semesters?.[key]}
      </option>
    ))

  const onSemesterSubmit = async () => {
    if (semesters) {
      const path = Path.Semester

      let key: string
      let value: string
      const isNewSemester = selectedSemester === 'new'

      if (isNewSemester) {
        value = String(newSemesterNumber)
        key = await request.bodyLessPost(`${path}/${value}`)
      } else {
        key = String(selectedSemester)
        value = semesters[key]
        await request.bodyLessPut(`${path}/${selectedSemester}`)
      }

      // let newSemesters = produce(semesters, (ns) => {
      //   if (!isNewSemester) {
      //     delete ns?.[key]
      //   }
      // })

      const newSemesters = {
        [key]: value,
        // ...newSemesters, How to avoid caching in our case? Whatever..
      }

      await mutate(newSemesters, true).then(() => {
        // close popover and refetch everything for semester
      })
    }
  }

  return (
    <Popover placement="auto-start">
      <PopoverTrigger>
        <Button variant="ghost">Semestr {currentSemester?.[1]}</Button>
      </PopoverTrigger>
      <Portal>
        <PopoverContent>
          <PopoverArrow />
          <PopoverHeader>Wybierz semestr</PopoverHeader>
          <PopoverCloseButton />
          <PopoverBody>
            <Select
              onChange={(e) => setSelectedSemester(e.target.value)}
              mb={4}
            >
              {semesters && (
                <>
                  {generateSemestersItems()}
                  <option value="new">Dodaj nowy</option>
                </>
              )}
            </Select>
            {selectedSemester === 'new' && (
              <SemesterNumberInput
                onChange={(val) => setNewSemesterNumber(val)}
                semester={newSemesterNumber}
              />
            )}
            <Button
              disabled={
                Number(selectedSemester) === Number(currentSemester?.[1])
              }
              onClick={() => onSemesterSubmit()}
            >
              {selectedSemester === 'new'
                ? 'Utwórz semestr oraz wybierz'
                : 'Wybierz semestr'}
            </Button>
          </PopoverBody>
        </PopoverContent>
      </Portal>
    </Popover>
  )
}
