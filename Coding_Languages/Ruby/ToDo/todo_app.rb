# todo_app.rb
class ToDoApp
  def initialize
    @tasks = []
  end

  def menu
    loop do
      puts "\n--- To-Do List ---"
      puts "1. Aufgaben anzeigen"
      puts "2. Aufgabe hinzufügen"
      puts "3. Aufgabe entfernen"
      puts "4. Beenden"
      print "Wähle eine Option: "
      choice = gets.chomp.to_i

      case choice
      when 1
        show_tasks
      when 2
        add_task
      when 3
        remove_task
      when 4
        puts "Tschüss! 😊"
        break
      else
        puts "Ungültige Option, bitte erneut versuchen!"
      end
    end
  end

  private

  def show_tasks
    if @tasks.empty?
      puts "Keine Aufgaben vorhanden."
    else
      puts "\nDeine Aufgaben:"
      @tasks.each_with_index do |task, index|
        puts "#{index + 1}. #{task}"
      end
    end
  end

  def add_task
    print "Gib die Aufgabe ein: "
    task = gets.chomp
    @tasks << task
    puts "\"#{task}\" wurde hinzugefügt."
  end

  def remove_task
    if @tasks.empty?
      puts "Keine Aufgaben zum Entfernen."
    else
      show_tasks
      print "Gib die Nummer der Aufgabe ein, die du entfernen möchtest: "
      index = gets.chomp.to_i - 1
      if index >= 0 && index < @tasks.length
        removed_task = @tasks.delete_at(index)
        puts "\"#{removed_task}\" wurde entfernt."
      else
        puts "Ungültige Nummer, bitte erneut versuchen."
      end
    end
  end
end

# Start der App
app = ToDoApp.new
app.menu
